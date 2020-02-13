using System;

namespace ExtentionMethodTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer custA = new Customer();
            custA.Cust_ID = 1;
            custA.CustType = (int)Customer.CustomerType.Retail;
            custA.CustName = "ABC Plastics";
            custA.CustLocation = "Worcester";


          
        }
    }
}
