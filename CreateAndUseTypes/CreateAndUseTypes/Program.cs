using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateAndUseTypes
{

    
    class Program
    {
        private protected int ddd;


        struct Point
         {
            public int x, y;
            public Point(int x, int y)
             {  
                 this.x = x;  
                 this.y = y;  
             }  
         }

        public class Student
        {

            public string StudentName { get; set; }

        }

        public static void ChangeReferenceType(Student std2)
        {
            std2.StudentName = "Mike";
        }

        public static void qube(ref int num)
        {
            num = num * num * num;
        }

        public static void qubeValue( int num)
        {
            num = num * num * num;
        }



        static void Main(string[] args)
        {

            DoubleTest();  // double is much quicker but less precise (base 2)
            DecimalTest(); // decimal is  slower but more precise, use for money calculations (base 10)




            ////// Pass byRef and ByVal Example
            //int original = 9;
            //Console.Write("\ncurrent value of Original is {0}\t", original);
            //qubeValue(original);
            //Console.WriteLine("\nNow (by Value) the current value of Original is {0}\t", original);
            //qube(ref original);
            //Console.WriteLine("\nNow the current value of Original is {0}\t", original);
            //Console.ReadLine();

            ////////////////////////////////

            //Student std1 = new Student();

            //std1.StudentName = "Bill";

            //ChangeReferenceType(std1);

            //Console.WriteLine(std1.StudentName);  // std1 and std2 are the same



            //Point myPoint = new Point(0, 0);      // a new value-type variable
            //Form myForm = new Form();              // a new reference-type variable

            //Test(myPoint, myForm);                // Test is a method defined below


            //// String.Concat example.
            //// String.Concat has many versions. Rest the mouse pointer on 
            //// Concat in the following statement to verify that the version
            //// that is used here takes three object arguments. Both 42 and
            //// true must be boxed.
            //Console.WriteLine(String.Concat("Answer", 42, true));

            //// List example.
            //// Create a list of objects to hold a heterogeneous collection 
            //// of elements.
            //List<object> mixedList = new List<object>();

            //// Add a string element to the list. 
            //mixedList.Add("First Group:");

            //// Add some integers to the list. 
            //for (int k = 1; k < 5; k++)
            //{
            //    // Rest the mouse pointer over j to verify that you are adding
            //    // an int to a list of objects. Each element j is boxed when 
            //    // you add j to mixedList.
            //    mixedList.Add(k);
            //}

            //// Add another string and more integers.
            //mixedList.Add("Second Group:");
            //for (int M = 5; M < 10; M++)
            //{
            //    mixedList.Add(M);
            //}

            //// Display the elements in the list. Declare the loop variable by 
            //// using var, so that the compiler assigns its type.
            //foreach (var item in mixedList)
            //{
            //    // Rest the mouse pointer over item to verify that the elements
            //    // of mixedList are objects.
            //    Console.WriteLine(item);
            //}

            //// The following loop sums the squares of the first group of boxed
            //// integers in mixedList. The list elements are objects, and cannot
            //// be multiplied or added to the sum until they are unboxed. The
            //// unboxing must be done explicitly.
            //var sum = 0;
            //for (var P = 1; P < 5; P++)
            //{
            //    // The following statement causes a compiler error: Operator 
            //    // '*' cannot be applied to operands of type 'object' and
            //    // 'object'. 
            //    //sum += mixedList[j] * mixedList[j]);

            //    // After the list elements are unboxed, the computation does 
            //    // not cause a compiler error.
            //    sum += (int)mixedList[P] * (int)mixedList[P];
            //}

            //// The sum displayed is 30, the sum of 1 + 4 + 9 + 16.
            //Console.WriteLine("Sum: " + sum);

            //// Output:
            //// Answer42True
            //// First Group:
            //// 1
            //// 2
            //// 3
            //// 4
            //// Second Group:
            //// 5
            //// 6
            //// 7
            //// 8
            //// 9
            //// Sum: 30
            ///

            //bool? myBool = null;
            //if (myBool)
            //{
            //    Console.WriteLine(myBool);
            //}


            // coalescing operator
           // Int32? ia = null;
           // Int32 ja = ia ?? 100;

           // string mightBeNull = null;

           // string mightNOTBeNull = mightBeNull ?? "ITS NULL";



           // string string3 = System.String.Empty;
           // string string4 = string3 ?? "ITS NULL";  // string4 = "" as string3 not null


           // Console.WriteLine("The value of the variable j is: " + ja);

           // // casting nullable to non nullable
           // Int32? i1 = null;  /// OK TO BE NULL HERE
           // Int32 j1 = (Int32)i1;  // BUT- get an error here because i1 IS NULL AND j1 is NOT nullable

           // int? nullable = null;
           // if (nullable == null)
           //     Console.WriteLine("It's a null!");
           // if (!nullable.HasValue)
           //     Console.WriteLine("It's a null!");

          


           // int? b = null;
           // if (b.HasValue)
           // {
           //     Console.WriteLine($"b is {b.Value}");
           // }
           // else
           // {
           //     Console.WriteLine("b does not have a value");
           // }

           // double? pi = 3.14;
           // char? letter = 'a';

           // int m2 = 10;
           // int? m = m2;

           // bool? flag = null;

           // // An array of a nullable type:
           // int?[] arr = new int?[10];

           // double? pi2;

           //// Console.WriteLine(pi2);  // does not compile because pi2 is null


           // decimal myDecimal = new decimal();
           // Type t = myDecimal.GetType();

           // if (t.IsValueType)
           // {
           //     Console.WriteLine("its a value type");
           // }

            //bool flag = false;
            //NumEnum testEnum = NumEnum.One;
            //// Get the type of myTestEnum.
            //Type t = testEnum.GetType();
            //// Get the IsValueType property of the myTestEnum variable.
            //flag = t.IsValueType;
            //Console.WriteLine("{0} is a value type: {1}", t.FullName, flag);






            // NULL STRING DOES NOT COMPILE
            //string nullstring_1;

            //string nullstring_2;

            //nullstring_2 += nullstring_1;

            //Console.WriteLine(nullstring_2);

            //double b2 = 12.45;
            //int x = 10;
            //b2 = b2 + x;
            //Console.WriteLine(b2);
            //float floaty = (float)b2;
            //Console.WriteLine(floaty);
            //int intTest = (int)floaty;
            //Console.WriteLine(intTest);


            //int x1 = 21;
            //int y1 = 5;
            //double b1 = x1 / y1;   // b1 is 4 (not 4.2) because the RHS are both integers
            //float f1 = x1 / y1;    // again, b1 is 4 (not 4.2)

            //double d2 = (x1 + y1) / y1;   // 5  -still integer as RHS are all integers
            //double d3 = x1 / d2;          // 4.2 double (becaue of double on RHS)

            //double d4 = (x1 / y1) * 7;    //  28
            //double d5 = (x1 / y1) * 3.0;  //     12
            //double d6 = (x1 / y1) * 3.55;  // 14.2

            //// Using the Convert Class

            //double dNumber = 23.15;

            //try
            //{
            //    // Returns 23
            //    int iNumber = System.Convert.ToInt32(dNumber);
            //}
            //catch (System.OverflowException)
            //{
            //    System.Console.WriteLine("Overflow in double to int conversion.");
            //}
            //// Returns True
            //bool bNumber = System.Convert.ToBoolean(dNumber);
            //bool bNumberZero = System.Convert.ToBoolean(0);

            //// Returns "23.15"
            //string strNumber = System.Convert.ToString(dNumber);

            //try
            //{
            //    // Returns '2'
            //    char chrNumber = System.Convert.ToChar(strNumber[0]);
            //}
            //catch (System.ArgumentNullException)
            //{
            //    System.Console.WriteLine("String is null");
            //}
            //catch (System.FormatException)
            //{
            //    System.Console.WriteLine("String length is greater than 1.");
            //}

            //// System.Console.ReadLine() returns a string and it
            //// must be converted.
            //int newInteger = 0;
            //try
            //{
            //    System.Console.WriteLine("Enter an integer:");
            //    newInteger = System.Convert.ToInt32(System.Console.ReadLine());
            //}
            //catch (System.ArgumentNullException)
            //{
            //    System.Console.WriteLine("String is null.");
            //}
            //catch (System.FormatException)
            //{
            //    System.Console.WriteLine("String does not consist of an " +
            //                    "optional sign followed by a series of digits.");
            //}
            //catch (System.OverflowException)
            //{
            //    System.Console.WriteLine(
            //    "Overflow in string to int conversion.");
            //}

            //System.Console.WriteLine("Your integer as a double is {0}",
            //                         System.Convert.ToDouble(newInteger));







            //// Dynamic variables
            //dynamic dynamicVariable = 100;
            //Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            //dynamicVariable = "Hello World!!";
            //Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            //dynamicVariable = true;
            //Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            //dynamicVariable = DateTime.Now;
            //Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            //double d = 765.12;

            //// Incompatible Data Type 
            ////   int i = d;  // Compile error 
            //// Explicit Type Casting 
            //int i = (int)d;

            //// Display Result     
            ////  Console.WriteLine("Value of i is ", +i);

            ////Byte b1 = 1;
            ////short s1 =0;

            ////float f1 = 1;
            ////double d1 = 0;

            ////  f1 = d1;

            ////d1 = f1;

            ////s1 = b1;       // implicit cast
            ////// b1 = s1;
            ////b1 = (byte)s1; // explicit cast


            ////   Byte >> Short >> int >> long >> float >> double 
            //// smaller types can be assigned to larger types without 



            //Point p = new Point(10, 10);    // new Point
            //object box = p;                 // box to object
            //p.x = 20;                       // set x (in the object)
            //Console.Write(((Point)box).x);  // unbox to Point and output
            //Console.WriteLine();

            //int i2 = 1;                     // declare j and assign value of 1       <---- starts as an int
            //object o = i2;                  // boxing                                <---- change it to an object (just set it to object)
            //int j = (int)o;                 // unboxing  (cast object to int)        <---- change it specifically back to an int
            //Console.WriteLine("J:" + 12);
            //Console.ReadLine();
        
        }

        private static void DecimalTest()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Decimal z = 0;
            for (int i = 0; i < iterations; i++)
            {
                Decimal x = i;
                Decimal y = x * i;
                z += y;
            }
            watch.Stop();
            Console.WriteLine("Decimal: " + watch.ElapsedTicks);
            Console.WriteLine(z);
        }

        static int iterations = 100000000;


        private static void DoubleTest()
        {
            System.Diagnostics.Stopwatch watch = new Stopwatch();
            watch.Start();
            Double z = 0;
            for (int i = 0; i < iterations; i++)
            {
                Double x = i;
                Double y = x * i;
                z += y;
            }
            watch.Stop();
            Console.WriteLine("Double: " + watch.ElapsedTicks);
            Console.WriteLine(z);
        }

        private static void Test(Point p, Form f)
        {
            p.x = 100;                       // No effect on MyPoint since p is a copy
            f.Text = "Hello, World!";        // This will change myForm’s caption since
                                             // myForm and f point to the same object
            f = null;                        // No effect on myForm
        }
    }
}
