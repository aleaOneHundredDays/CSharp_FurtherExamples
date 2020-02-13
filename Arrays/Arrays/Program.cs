using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            // defining array with size 5.add values later on
            int[] intArray1 = new int[5];

            // defining array with size 5 and adding values at the same time
            int[] intArray2 = new int[5] { 1, 2, 3, 4, 5 };

            // defining array with 5 elements which indicates the size of an array
            int[] intArray3 = { 1, 2, 3, 4, 5 };


            Array arrayToSet = Array.CreateInstance(typeof(int), new int[1] { 5 }, new int[1] { 1 });

            arrayToSet.SetValue(11, 1);
            arrayToSet.SetValue(12, 2);
            arrayToSet.SetValue(13, 3);
            arrayToSet.SetValue(14, 4);
            arrayToSet.SetValue(15, 5);

            for (int i = 1; i <= arrayToSet.Length; i++)
                Console.WriteLine("Array value {0} at position {1}", arrayToSet.GetValue(i), i);

            Array arrayToSet2 = Array.CreateInstance(typeof(string), 5);
            arrayToSet2.SetValue("ABCDEFGHIJKL", 0);
            arrayToSet2.SetValue("DEFGHIJKLMNO", 1);
            arrayToSet2.SetValue("GHIJKLMNOPQR", 2);
            arrayToSet2.SetValue("JKLMNOPQRSTU", 3);
            arrayToSet2.SetValue("MNOPQRVWXVWX", 4);

            for (int i = 1; i < arrayToSet2.Length; i++)
                Console.WriteLine("Array value {0} at position {1}", arrayToSet2.GetValue(i), i);

            // creates multidimensional array (4 dimensions)
            //int[] myLengthsArray = new int[4] { 2, 3, 4, 5 };
            //Array arrayToSet3 = Array.CreateInstance(typeof(string), myLengthsArray);

            int[] myLengthsArray = new int[4] { 2, 3, 4, 5 };
            Array my4DArray = Array.CreateInstance(typeof(String), myLengthsArray);
            for (int i = my4DArray.GetLowerBound(0); i <= my4DArray.GetUpperBound(0); i++)
                for (int j = my4DArray.GetLowerBound(1); j <= my4DArray.GetUpperBound(1); j++)
                    for (int k = my4DArray.GetLowerBound(2); k <= my4DArray.GetUpperBound(2); k++)
                        for (int l = my4DArray.GetLowerBound(3); l <= my4DArray.GetUpperBound(3); l++)
                        {
                            int[] myIndicesArray = new int[4] { i, j, k, l };
                            my4DArray.SetValue(Convert.ToString(i) + j + k + l, myIndicesArray);
                        }

            // Displays the values of the Array.
            Console.WriteLine("The four-dimensional Array contains the following values:");
            PrintValues2(my4DArray);



            // implicitly typed arrays

            var contacts = new[]
            {
                new {
                    Name = " Eugene Zabokritski",
                    PhoneNumbers = new[] { "206-555-0108", "425-555-0001" }
                },
                new {
                    Name = " Hanying Feng",
                    PhoneNumbers = new[] { "650-555-0199" }
                }
            };





            int[] intArr = new int[5] { 2, 4, 1, 3, 5 };

            int[] intArrDest = new int[5] {0,0,0,0,0} ;

            int[] intArrayAgain = new int[3];

            Array.Copy(intArr, intArrDest, 5);

            Array.Copy(intArr, intArrayAgain, 2);

            Console.WriteLine("Array Initially");
            for (int i = 0; i < intArr.Length; i++)
                Console.WriteLine("Array value {0} at position {1}", intArr.GetValue(i), i);

            Array.Sort(intArr);
            Console.WriteLine("Array Sorted");

            for (int i = 0; i < intArr.Length; i++)
                Console.WriteLine("Array value {0} at position {1}", intArr.GetValue(i), i);
            
            Array.Reverse(intArr);
            Console.WriteLine("Array Reversed");


            for (int i = 0; i < intArr.Length; i++)
                Console.WriteLine("Array value {0} at position {1}", intArr.GetValue(i), i);


            Array array = Array.CreateInstance(typeof(int), new int[1] { 5 }, new int[1] { 1 });

            array.SetValue(1, 1);
            array.SetValue(2, 2);
            array.SetValue(3, 3);
            array.SetValue(4, 4);
            array.SetValue(5, 5);

            for (int i = 1; i <= array.Length; i++)
                Console.WriteLine("Array value {0} at position {1}", array.GetValue(i), i);



            // Creates and initializes a new integer array and a new Object array.
            int[] myIntArray = new int[5] { 1, 2, 3, 4, 5 };
            Object[] myObjArray = new Object[5] { 26, 27, 28, 29, 30 };

            // Prints the initial values of both arrays.
            Console.WriteLine("Initially,");
            Console.Write("integer array:");
            PrintValues(myIntArray);
            Console.Write("Object array: ");
            PrintValues(myObjArray);

            // Copies the first two elements from the integer array to the Object array.
            System.Array.Copy(myIntArray, myObjArray, 2);


            // Prints the values of the modified arrays.
            Console.WriteLine("\nAfter copying the first two elements of the integer array to the Object array,");
            Console.Write("integer array:");
            PrintValues(myIntArray);
            Console.Write("Object array: ");
            PrintValues(myObjArray);

            // Copies the last two elements from the Object array to the integer array.
            System.Array.Copy(myObjArray, myObjArray.GetUpperBound(0) - 1, myIntArray, myIntArray.GetUpperBound(0) - 1, 2);

            // Prints the values of the modified arrays.
            Console.WriteLine("\nAfter copying the last two elements of the Object array to the integer array,");
            Console.Write("integer array:");
            PrintValues(myIntArray);
            Console.Write("Object array: ");
            PrintValues(myObjArray);



            int[,] numbers2D = new int[4, 2] { { 9, 99 }, { 3, 33 }, { 5, 55 },{1,11 } };
            //// Or use the short form:
            //// int[,] numbers2D = { { 9, 99 }, { 3, 33 }, { 5, 55 } };

            //Console.WriteLine(numbers2D[0,0]);
            //Console.WriteLine(numbers2D[1,0]);
            //Console.WriteLine(numbers2D[2,1]);

            //foreach (int i in numbers2D)
            //{
            //    System.Console.Write("{0} ", i);
            //}



            //// Declare a single-dimensional array. 
            //int[] array1 = new int[5];

            //// Declare and set array element values.
            //int[] array2 = new int[] { 1, 3, 5, 7, 9 };

            //// Alternative syntax.
            //int[] array3 = { 1, 2, 3, 4, 5, 6 };

            //// Declare a two dimensional array.
            //int[,] multiDimensionalArray1 = new int[2, 3];

            //// Declare and set array element values.
            //int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            //// Declare and set array element values.
            //int[,,] multiDimensionalArray3 = { { { 1, 2, 3 }, { 4, 5, 6 }, { 1, 2, 3 } } };

            //int[,,,] multiDimensionalArray4 = {
            //    {
            //        {
            //            { 1, 2, 3 }, { 4, 5, 6 }, { 1, 2, 3 }, { 4, 5, 6 }
            //        }
            //    }
            //};

            ///// Multi dimensional arrays
            //// Two-dimensional array.
            //int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            //// The same array with dimensions specified.
            //int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            //// A similar array with string elements.
            //string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
            //                            { "five", "six" } };

            //// [x,y] 
            //string[,] array2DbX = new string[2, 4] { { "one", "two", "three", "four" }, { "five", "six", "seven", "eight" } };

            //// Getting the total count of elements or the length of a given dimension.
            //var allLength = array2Db.Length;
            //var total = 1;
            //for (int i = 0; i < array2Db.Rank; i++)
            //{
            //    total *= array2Db.GetLength(i);
            //}
            //System.Console.WriteLine("{0} equals {1}", allLength, total);


            //// Three-dimensional array.
            //int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
            //                     { { 7, 8, 9 }, { 10, 11, 12 } } };

            //// The same array with dimensions specified.
            //int[,,] array3Da = new int[2, 2, 3]
            //{
            //    {
            //        { 1, 2, 3 },
            //        { 4, 5, 6 }
            //    },
            //    {
            //        { 7, 8, 9 },
            //        { 10, 11, 12 }
            //    }
            //};


            //// The same array with dimensions specified.
            //int[,,,] array3Db = new int[1, 1, 1, 1]
            //{
            //    {{ 1} ,  {1},  {1 } , {1} } }}

            //};

            
            int[,,,] am = new int[2, 3, 3, 3]
    { 
        { 
            { 
                { 1, 2, 3 }, 
                { 4, 5, 6 },
                { 7, 8, 9 } 
            },
            {
                { 11, 12, 13 }, 
                { 14, 15, 16 }, 
                { 17, 18, 19 } 
            }, 
            { 
                { 21, 22, 23 }, 
                { 24,25, 26 }, 
                { 27, 28, 99 }
            } 
        },
        {
            {
                { 31, 32, 33 },
                { 34, 35, 36 },
                { 37, 38, 39 }
            }, 
            { 
                { 41, 42, 43 },
                { 44, 45, 46 }, 
                { 47, 48, 49 }
            }, 
            { 
                { 51, 52, 53 },
                { 54, 55, 56 },
                { 57, 58, 59 }
            } 
        } 
    };

            Console.WriteLine(am[0,0,0,0]);
            Console.WriteLine(am[1,0,0,0]);
            Console.WriteLine(am[0,1,1,1]);
            Console.WriteLine(am[0,1,1,2]);


            int[,,,] am2 = new int[1, 1, 1, 1]
      {
        {
            {
                { 1 }      
            },
      
        }
            
     };





            // Getting the total count of elements or the length of a given dimension.
            var allLengtha = am2.Length;
            var totalb = 1;
            for (int i = 0; i < am2.Rank; i++)
            {
                totalb *= am2.GetLength(i);
            }
            System.Console.WriteLine("{0} equals {1}", allLengtha, totalb);


            //// Getting the total count of elements or the length of a given dimension.
            //var allLength = array3D.Length;
            //var total = 1;
            //for (int i = 0; i < array3D.Rank; i++)
            //{
            //    total *= array3D.GetLength(i);
            //}
            //System.Console.WriteLine("{0} equals {1}", allLength, total);



            // Declare a jagged array.
            int[][] jaggedArray = new int[6][];

            // Set the values of the first array in the jagged array structure.
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
        }


        public static void PrintValues(Object[] myArr)
        {
            foreach (Object i in myArr)
            {
                Console.Write("\t{0}", i);
            }
            Console.WriteLine();
        }

        public static void PrintValues(int[] myArr)
        {
            foreach (int i in myArr)
            {
                Console.Write("\t{0}", i);
            }
            Console.WriteLine();
        }

        public static void PrintValues2(Array myArr)
        {
            System.Collections.IEnumerator myEnumerator = myArr.GetEnumerator();
            int i = 0;
            int cols = myArr.GetLength(myArr.Rank - 1);
            while (myEnumerator.MoveNext())
            {
                if (i < cols)
                {
                    i++;
                }
                else
                {
                    Console.WriteLine();
                    i = 1;
                }
                Console.Write("\t{0}", myEnumerator.Current);
            }
            Console.WriteLine();
        }
    }
}
