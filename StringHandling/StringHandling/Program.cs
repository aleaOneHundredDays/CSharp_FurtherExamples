using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StringHandling
{

    public class Vegetable
    {
        public Vegetable(string name) => Name = name;
        public string Name { get; }
        public override string ToString() => Name;
    }

    class Program
    {
        public enum Unit { item, kilogram, gram, dozen };

        static async Task Main(string[] args)
        {
            try
            {

                // create stringbuilder and append some text
                StringBuilder stringToRead22 = new StringBuilder();
                 stringToRead22.AppendLine("ABC");
                //stringToRead22.AppendLine("and 2nd line");
                //stringToRead22.AppendLine("Characters in 1st line to read");
                //stringToRead22.AppendLine("and 2nd line");
                //stringToRead22.AppendLine("and the end, end end");

                StringReader readerA = new StringReader(stringToRead22.ToString());

                int aPeek = readerA.Peek();

                string textRead = readerA.ReadToEnd();
                Console.WriteLine(textRead);

                int a = readerA.Peek();

                // using new stringreader, read text in StringBuilder
                using (StringReader reader = new StringReader(stringToRead22.ToString()))
                {
                    string readText = await reader.ReadToEndAsync();
                    Console.WriteLine(readText);
                }


                // Create a StringBuilder that expects to hold 50 characters.
                // Initialize the StringBuilder with "ABC".
                StringBuilder sb22 = new StringBuilder("ABC", 50);

                // Append three characters (D, E, and F) to the end of the StringBuilder.
                sb22.Append(new char[] { 'D', 'E', 'F' });

                // Append a format string to the end of the StringBuilder.
                sb22.AppendFormat("GHI{0}{1}", 'J', 'k');

                // Display the number of characters in the StringBuilder and its string.
                Console.WriteLine("{0} chars: {1}", sb22.Length, sb22.ToString());

                // Insert a string at the beginning of the StringBuilder.
                sb22.Insert(0, "Alphabet: ");

                // Replace all lowercase k's with uppercase K's.
                sb22.Replace('k', 'K');


                // Display the number of characters in the StringBuilder and its string.
                Console.WriteLine("{0} chars: {1}", sb22.Length, sb22.ToString());




                var item = new Vegetable("eggplant");
                var date = DateTime.Now;
                var price = 1.99m;
                var unit = Unit.item;
                string toCaps = item.Name;  // implicit cast to string
                Console.WriteLine($"On {date}, the price of {item} was {price} per {unit}. Called: {toCaps.ToUpper()}");


                LastCharExample();

                string s11 = "Hello ";
                string s22 = s11;
                s11 += "World";  // << Modified s1, but what about s2? (Hint - created a new string here...)

                Console.WriteLine(s22);    //Output =  Hello   << It stays the same, because it is pointing to the ORIGINAL s11 object
                Console.WriteLine(s11);    // Outputs 'Hello World'  (Modified s11 object)


                // calling check() Method 
                check("1234", 3);
                check("Tsunami", 3);
                check("psyc0lo", 4);

                // declaring and initializing string s1 
                string s1 = new String(new char[] {'a',
                        '\uD800', '\uDC00', 'z' });

                check(s1, 1);
            }
            catch (ArgumentNullException e)
            {

                Console.Write("Exception Thrown: ");
                Console.Write("{0}", e.GetType(), e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {

                Console.Write("Exception Thrown: ");
                Console.Write("{0}", e.GetType(), e.Message);
            }



            EnumerateAndDisplay("Test Case");
            EnumerateAndDisplay("This is a sentence.");
            EnumerateAndDisplay("Has\ttwo\ttabs");
            EnumerateAndDisplay("Two\nnew\nlines");


            string path = "c:\\mypath\\to\\myfile.txt";

            //  The @ allows you to do this:
            string path2 = @"c:\mypath\to\myfile.txt";

            Console.WriteLine(path);
            Console.WriteLine(path2);


            string name = "Forrest";
            string surname = "Gump";
            int year = 3;
            string sDollarSign = $"My name is {name} {surname} and once I run more than {year} years.";
            Console.WriteLine(sDollarSign);
            string expectedResult = "My name is Forrest Gump and once I run more than 3 years.";
            Console.WriteLine(expectedResult);


            string text = "World";
            var message = $"Hello, {text}";
            Console.WriteLine(message); // Prints Hello, World

            var anInt = 1;
            var aBool = true;
            var aString = "3";
            var formated = $"{anInt},{aBool},{aString}";

            Console.WriteLine(formated);


            String testString = "Arnie Volestrangler";

            testString = testString.ToLower();
            Console.WriteLine(testString);


            string factMessage = "Extension methods have all the capabilities of regular static methods.";

            // Write the string and include the quotation marks.
            Console.WriteLine($"\"{factMessage}\"");

            // This search returns the substring between two strings, so 
            // the first index is moved to the character just after the first string.
            int first = factMessage.IndexOf("methods") + "methods".Length;
            int last = factMessage.LastIndexOf("methods");
            string str2 = factMessage.Substring(first, last - first);
            Console.WriteLine($"Substring between \"methods\" and \"methods\": '{str2}'");


            // Search Strings
            string factMessage2 = "Extension methods have all the capabilities of regular static methods.";

            // Write the string and include the quotation marks.
            Console.WriteLine($"\"{factMessage2}\"");

            // Simple comparisons are always case sensitive!
            bool containsSearchResult = factMessage2.Contains("extension");
            Console.WriteLine($"Starts with \"extension\"? {containsSearchResult}");

            // For user input and strings that will be displayed to the end user, 
            // use the StringComparison parameter on methods that have it to specify how to match strings.
            bool ignoreCaseSearchResult = factMessage2.StartsWith("extension", System.StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine($"Starts with \"extension\"? {ignoreCaseSearchResult} (ignoring case)");

            bool endsWithSearchResult = factMessage2.EndsWith(".", System.StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine($"Ends with '.'? {endsWithSearchResult}");



            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("TextFile.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }



            // StringReader Ex 1
            StringBuilder stringToRead = new StringBuilder();
            stringToRead.AppendLine("Characters in 1st line to read");
            stringToRead.AppendLine("and 2nd line");
            stringToRead.AppendLine("and the end");

            using (System.IO.StringReader reader = new System.IO.StringReader(stringToRead.ToString()))
            {
                string readText = await reader.ReadToEndAsync();
                Console.WriteLine(readText);
            }



            //stringReader Ex 2
            // From textReaderText, create a continuous paragraph 
            // with two spaces between each sentence.
            string aLine, aParagraph = null;
            String textReaderText = "HERE IS SOME TEXT";
            StringReader strReader = new StringReader(textReaderText);

            strReader.Close();


            while (true)
            {
                aLine = strReader.ReadLine();
                if (aLine != null)
                {
                    aParagraph = aParagraph + aLine + " ";
                }
                else
                {
                    aParagraph = aParagraph + "\n";
                    break;
                }
            }
            Console.WriteLine("Modified text:\n\n{0}", aParagraph);


            // Create a StringBuilder that expects to hold 50 characters.
            // Initialize the StringBuilder with "ABC".
            StringBuilder sb = new StringBuilder("ABC", 50);

            StringBuilder sb2 = new StringBuilder("AVERYLONGSTRINGYOUWOULDNOTWANTTOSPELL", 5, 4, 100);
            sb2.Append(10.2);
            sb2.Append('Y');
            sb2.Append(true);
            sb2.Append(false);
            sb2.Append("AVERY", 0, 5);
            sb2.Append("START", 0, 4);
            sb2.Replace("LONG", "SHORT");
            sb2.Insert(0, "BEGIN");
            sb2.Append("FRONTBACK", 5, 4);

            char[] a1 = new char[] { 'X', 'Y', 'Z' };

            sb2.Append(new char[] { 'X', 'Y', 'Z' });
            sb2.Append(a1);
            Console.WriteLine(sb2.ToString());


            //// Append three characters (D, E, and F) to the end of the StringBuilder.
            //sb.Append(new char[] { 'D', 'E', 'F' });

            //// Append a format string to the end of the StringBuilder.
            //sb.AppendFormat("GHI{0}{1}", 'J', 'k');

            //// Display the number of characters in the StringBuilder and its string.
            //Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());

            //// Insert a string at the beginning of the StringBuilder.
            //sb.Insert(0, "Alphabet: ");

            //// Replace all lowercase k's with uppercase K's.
            //sb.Replace('k', 'K');

            //// Display the number of characters in the StringBuilder and its string.
            //Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());


            Console.WriteLine("Here we go");
            Console.ReadLine();
        }



        static void EnumerateAndDisplay(String phrase)
        {
            Console.WriteLine("The characters in the string \"{0}\" are:",
                              phrase);

            int CharCount = 0;
            int controlChars = 0;
            int alphanumeric = 0;
            int punctuation = 0;

            foreach (var ch in phrase)
            {
                Console.Write("'{0}' ", !Char.IsControl(ch) ? ch.ToString() :
                                 "0x" + Convert.ToUInt16(ch).ToString("X4"));  // X4 represents the number of leading zeros to include

                if (Char.IsLetterOrDigit(ch))
                    alphanumeric++;
                else if (Char.IsControl(ch))
                    controlChars++;
                else if (Char.IsPunctuation(ch))
                    punctuation++;
                CharCount++;
            }

            Console.WriteLine("\n Total characters:        {0,3}", CharCount);
            Console.WriteLine("   Alphanumeric characters: {0,3}", alphanumeric);
            Console.WriteLine("   Punctuation characters:  {0,3}", punctuation);
            Console.WriteLine("   Control Characters:      {0,3}\n", controlChars);
        }

        public static void check(string s, int i)
        {

            // checking condition 
            // using IsSurrogatePair() Method 
            bool val = Char.IsSurrogatePair(s, i);

            // checking 
            if (val)
                Console.WriteLine("String '{0}' contains "
                  + "Surrogate pairs at s[{1}] and s[{2}]",
                                              s, i, i + 1);

            else
                Console.WriteLine("String '{0}' does't contain any "
                           + "Surrogate pairs at s[{1}] and s[{2}]",
                                                        s, i, i + 1);

        }

        public static void LastCharExample() 
        {

            var name = "Fred";
            Console.WriteLine($"Hello, {name}. It's a pleasure to meet you!");

            string smallString = "abcd";
            Console.WriteLine(smallString.Length);

            string intro = "Find the last occurrence of a character using different " +
                       "values of StringComparison.";
            string resultFmt = "Comparison: {0,-28} Location: {1,3}";

            // Define a string to search for.
            // U+00c5 = LATIN CAPITAL LETTER A WITH RING ABOVE
            string CapitalAWithRing = "\u00c5";

            // Define a string to search. 
            // The result of combining the characters LATIN SMALL LETTER A and COMBINING 
            // RING ABOVE (U+0061, U+030a) is linguistically equivalent to the character 
            // LATIN SMALL LETTER A WITH RING ABOVE (U+00e5).
            string cat = "Now here is A Cheshire c" + "\u0061\u030a" + "t called Chester";
            int loc = 0;
            StringComparison[] scValues = {
        StringComparison.CurrentCulture,
        StringComparison.CurrentCultureIgnoreCase,
        StringComparison.InvariantCulture,
        StringComparison.InvariantCultureIgnoreCase,
        StringComparison.Ordinal,
        StringComparison.OrdinalIgnoreCase };

            // Clear the screen and display an introduction.
            Console.Clear();
            Console.WriteLine(intro);

            // Display the current culture because culture affects the result. For example, 
            // try this code example with the "sv-SE" (Swedish-Sweden) culture.

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Console.WriteLine("The current culture is \"{0}\" - {1}.",
                               Thread.CurrentThread.CurrentCulture.Name,
                               Thread.CurrentThread.CurrentCulture.DisplayName);

            // Display the string to search for and the string to search.
            Console.WriteLine("Search for the string \"{0}\" in the string \"{1}\"",
                               CapitalAWithRing, cat);
            Console.WriteLine();


            // Note that in each of the following searches, we look for 
            // LATIN CAPITAL LETTER A WITH RING ABOVE in a string that contains 
            // LATIN SMALL LETTER A WITH RING ABOVE. A result value of -1 indicates 
            // the string was not found.
            // Search using different values of StringComparsion. Specify the start 
            // index and count. 

            Console.WriteLine($"Part 1: Start index and count are specified. Cat Length: {cat.Length}");
            foreach (StringComparison sc in scValues)
            {
                loc = cat.LastIndexOf(CapitalAWithRing, cat.Length - 1, cat.Length, sc);
                Console.WriteLine(resultFmt, sc, loc);
            }

            // Search using different values of StringComparsion. Specify the 
            // start index. 
            Console.WriteLine("\nPart 2: Start index is specified.");
            foreach (StringComparison sc in scValues)
            {
                loc = cat.LastIndexOf(CapitalAWithRing, cat.Length - 1, sc);
                Console.WriteLine(resultFmt, sc, loc);
            }


            // Search using different values of StringComparsion. 
            Console.WriteLine("\nPart 3: Neither start index nor count is specified.");
            foreach (StringComparison sc in scValues)
            {
                loc = cat.LastIndexOf(CapitalAWithRing, sc);
                Console.WriteLine(resultFmt, sc, loc);

             int x=  cat.LastIndexOf("hes",StringComparison.InvariantCultureIgnoreCase);
            }

        }



    }
}
