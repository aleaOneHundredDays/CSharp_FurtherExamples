using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;

namespace LibraryServiceSolution
{

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost server = new ServiceHost(typeof(LibraryService));

            Console.WriteLine("Your service has started...");
            Console.ReadLine();

            //server.Close();

        }
    }
}
