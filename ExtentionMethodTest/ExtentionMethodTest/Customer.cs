using System;
using System.Collections.Generic;
using System.Text;

namespace ExtentionMethodTest
{
    class Customer
    {
        private int _cust_ID;
        private int _custType;
        private string _custName;
        private string _custLocation;

        public enum CustomerType
        {
            Retail = 1,
            Wholesale = 2,
            Export = 3,
            Internal = 4

        }

        public Customer(int cust_ID,string custType, string custName, string custLocation)
        {


        }

        public Customer()
        {

        }

        public int Cust_ID {
            get { return _cust_ID;}
            set { _cust_ID = value;}
        }

        public int CustType
        {
            get { return _custType; }
            set { _custType = value; }
        }
        public string CustName
        {
            get { return _custName; }
            set { _custName = value; }
        }
        public string CustLocation
        {
            get { return _custLocation; }
            set { _custLocation = value; }
        }
       


    }
}
