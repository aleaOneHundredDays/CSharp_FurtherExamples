//Copy from   thottams@microsoft.com 15 Aug 2006 8:29 PM 
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System.IO;

namespace ConsoleApplication1
{
    public class CodeDomSample
    {
        CodeCompileUnit GenerateCSharpCode()
        {
            var compileUnit = new CodeCompileUnit();

            // Create a NameSpace - "namespace CodeDomSampleNS"
            //
            var codedomsamplenamespace = new CodeNamespace("CodeDomSampleNS");

            // Create using statement - "using System;"
            //
            var firstimport = new CodeNamespaceImport("System");

            // Add the using statement to the namespace -
            // namespace CodeDomSampleNS {
            //      using System;
            //
            codedomsamplenamespace.Imports.Add(firstimport);

            // Create a type inside the namespace - public class CodeDomSample
            //
            var newType = new CodeTypeDeclaration("CodeDomSample") { Attributes = MemberAttributes.Public };

            // Create a Main method which will be entry point for the class
            // public static void Main
            //
            var mainmethod = new CodeEntryPointMethod();

            // Add an expression inside Main -
            //  Console.WriteLine("Inside Main ...");
            var mainexp1 = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.Console"),
                "WriteLine", new CodePrimitiveExpression("Inside Main ..."));
            mainmethod.Statements.Add(mainexp1);

            // Add another expression inside Main
            //  CodeDomSample cs = new CodeDomSample()
            //
            CodeStatement cs = new CodeVariableDeclarationStatement(typeof(CodeDomSample), "cs", new CodeObjectCreateExpression(new CodeTypeReference(typeof(CodeDomSample))));
            mainmethod.Statements.Add(cs);

            // At the end of the CodeStatements we should have constructed the following
            // public static void Main() {
            //      Console.WriteLine("Inside Main ...");
            //      CodeDomSample cs = new CodeDomSample();
            // }

            // Create a constructor for the CodeDomSample class
            // public CodeDomSample() { }
            //
            var constructor = new CodeConstructor { Attributes = MemberAttributes.Public };

            // Add an expression to the constructor
            // public CodeDomSample() { Comsole.WriteLine("Inside CodeDomSample Constructor ...");
            //
            var constructorexp = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("System.Console"), "WriteLine", new CodePrimitiveExpression("Inside CodeDomSample Constructor ..."));
            constructor.Statements.Add(constructorexp);

            // Add constructor and mainmethod to type
            //
            newType.Members.Add(constructor);
            newType.Members.Add(mainmethod);

            // Add the type to the namespace
            //
            codedomsamplenamespace.Types.Add(newType);

            // Add the NameSpace to the CodeCompileUnit
            //
            compileUnit.Namespaces.Add(codedomsamplenamespace);

            // Return the CompileUnit
            //
            return compileUnit;
        }

        // Generate code for a particular provider and compile it
        //
        void GenerateCode(CodeCompileUnit ccu, String codeprovider)
        {
            var cp = new CompilerParameters();
            String sourceFile;

            switch (codeprovider)
            {
                case "CSHARP":
                    // Generate Code from Compile Unit using CSharp code provider
                    //
                    var csharpcodeprovider = new CSharpCodeProvider();

                    if (csharpcodeprovider.FileExtension[0] == '.')
                    {
                        sourceFile = "CSharpSample" + csharpcodeprovider.FileExtension;
                    }
                    else
                    {
                        sourceFile = "CSharpSample." + csharpcodeprovider.FileExtension;
                    }
                    var tw1 = new IndentedTextWriter(new StreamWriter(sourceFile, false), "    ");
                    csharpcodeprovider.GenerateCodeFromCompileUnit(ccu, tw1, new CodeGeneratorOptions());
                    tw1.Close();
                    cp.GenerateExecutable = true;
                    cp.OutputAssembly = "CSharpSample.exe";
                    cp.GenerateInMemory = false;
                    csharpcodeprovider.CompileAssemblyFromDom(cp, ccu);
                    break;
                case "VBASIC":
                    // Generate Code from Compile Unit using VB code provider
                    //
                    var vbcodeprovider = new VBCodeProvider();
                    if (vbcodeprovider.FileExtension[0] == '.')
                    {
                        sourceFile = "VBSample" + vbcodeprovider.FileExtension;
                    }
                    else
                    {
                        sourceFile = "VBSample." + vbcodeprovider.FileExtension;
                    }
                    var tw2 = new IndentedTextWriter(new StreamWriter(sourceFile, false), "    ");
                    vbcodeprovider.GenerateCodeFromCompileUnit(ccu, tw2, new CodeGeneratorOptions());
                    tw2.Close();
                    cp.GenerateExecutable = true;
                    cp.OutputAssembly = "VBSample.exe";
                    cp.GenerateInMemory = false;
                    vbcodeprovider.CompileAssemblyFromDom(cp, ccu);
                    break;
            }
        }

        // Another sample of hardcoding the code in a string and compiling it using the CSharpCodeProvider
        //
        public void CSharpCodeExample()
        {
            const string sourcecode = "\nusing System;\npublic class Sample \n{\n    static void Main()\n    {\n        Console.WriteLine(\"This is a test\");\n    }\n}";
            var provider = new CSharpCodeProvider();
            var cp = new CompilerParameters { GenerateExecutable = true, OutputAssembly = "Result.exe", GenerateInMemory = false };
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourcecode);
            if (cr.Errors.Count > 0)
            {
                Console.WriteLine("Errors building {0} into {1}", sourcecode, cr.PathToAssembly);
                foreach (CompilerError ce in cr.Errors)
                {
                    Console.WriteLine("  {0}", ce);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Source \n \n {0} \n \n \n built into {1} successfully.", sourcecode, cr.PathToAssembly);
            }
        }

        static public void Main()
        {
            var cds = new CodeDomSample();
            cds.CSharpCodeExample();
            CodeCompileUnit ccu = cds.GenerateCSharpCode();
            cds.GenerateCode(ccu, "CSHARP");
            cds.GenerateCode(ccu, "VBASIC");
        }
    }
}
