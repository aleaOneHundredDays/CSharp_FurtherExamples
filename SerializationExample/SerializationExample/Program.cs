using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationExample
{
    class Program
    {
        const string FileName = @"../../../SavedLoan.bin";
        static void Main(string[] args)
        {
            Loan TestLoan = new Loan(10000.0, 7.5, 36, "Neil Black");

            if (File.Exists(FileName))
            {
                Console.WriteLine("Reading saved file");
                Stream openFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                TestLoan = (Loan)deserializer.Deserialize(openFileStream);
                TestLoan.TimeLastLoaded = DateTime.Now;
                openFileStream.Close();
            }


            TestLoan.PropertyChanged += (_, __) => Console.WriteLine($"New customer value: {TestLoan.Customer}");

            TestLoan.Customer = "Henry Clay";
            Console.WriteLine(TestLoan.InterestRatePercent);
            TestLoan.InterestRatePercent = 7.1;
            Console.WriteLine(TestLoan.InterestRatePercent);

            Stream SaveFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(SaveFileStream, TestLoan);
            SaveFileStream.Close();

        
        }
    }
}
