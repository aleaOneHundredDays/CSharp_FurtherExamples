using System;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {

            TempRecord tempRecord = new TempRecord();
            // Use the indexer's set accessor
            tempRecord[3] = 58.3F;
            tempRecord[5] = 60.1F;
            tempRecord[1] = 25.1F;
            tempRecord[4] = 15.5F;

            TempRecord tempRecord2 = new TempRecord();
            // Use the indexer's set accessor
            tempRecord2[3] = 100.3F;
            tempRecord2[5] = 200.1F;
            tempRecord2[1] = 300.1F;
            tempRecord2[4] = 400.5F;

            // Use the indexer's get accessor
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine("Element tempRecord #{0} = {1}", i, tempRecord[i]);
             //   System.Console.WriteLine("Element #{0} = {1}", i, tempRecord.Length);

                System.Console.WriteLine("Element tempRecord2 #{0} = {1}", i, tempRecord2[i]);
             //   System.Console.WriteLine("Element #{0} = {1}", i, tempRecord2.Length);

            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();


            //// creating an object of parent class which 
            //// acts as primary address for using Indexer 
            //IndexerCreation ic = new IndexerCreation();

            //// Inserting values in ic[] 
            //// Here we are using the object 
            //// of class as an array 
            //ic[0] = "C";
            //ic[1] = "CPP";
            //ic[2] = "CSHARP";

            

            //Console.Write("Printing values stored in objects used as arrays\n");

            //// printing values  
            //Console.WriteLine("First value = {0}", ic[0]);
            //Console.WriteLine("Second value = {0}", ic[1]);
            //Console.WriteLine("Third value = {0}", ic[2]); ;
        }
    }

    class TempRecord
    {
        // Array of temperature values
        private float[] temps = new float[10] { 56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
                                            61.3F, 65.9F, 62.1F, 59.2F, 57.5F };

        // To enable client code to validate input 
        // when accessing your indexer.
        public int Length
        {
            get { return temps.Length; }
        }

        private int houseNumberValue;

        public int houseNumber
        {
            get { return houseNumberValue; }
            set { houseNumberValue = value; }
        }



        // Indexer declaration.
        // If index is out of range, the temps array will throw the exception.
        public float this[int index]
        {
            get
            {
                return temps[index];
            }

            set
            {
                temps[index] = value;
            }
        }
    }



    // class declaration 
    class IndexerCreation
    {

        // class members 
        private string[] val = new string[3];

        // Indexer declaration 
        // Here pubic is the modifier 
        // string is the return type of  
        // Indexer and "this" is the keyword 
        // having parameters list 
        public string this[int index]
        {

            // get Accessor 
            // retrieving the values  
            // stored in val[] array 
            // of strings 
            get
            {

                return val[index];
            }

            // set Accessor 
            // setting the value at  
            // passed index of val 
            set
            {

                // value keyword is used 
                // to define the value  
                // being assigned by the 
                // set indexer.  
                val[index] = value;
            }
        }
    }
}
