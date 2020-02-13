using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndConstructors
{
    class Person
    {
        string _fname;
        string _sname;

        int age;

        public string Forename
        {
            get { return _fname; }
            set
            {
                _fname = value;
            }
        }


        public string surname 
        {
            get { return _sname;    }
            set {
                    if (surname.Length > 10)
                    {
                        _sname = "BLANK";
                    }
                    else
                    {

                        _sname = value;

                    }
                }
        }


        public Person(string ForeName, string SurName) 
        {
            _fname = ForeName;
            _sname = SurName;

        }

    }

    class Employee : Person
    {
        string _jobTitle;
        int _yearJoined;
        decimal _payRate;

        private static string _CompanyName;

        public Employee(string jobTitle, int yearJoined, decimal payRate) : base(string.Empty, string.Empty) 
        {
            _jobTitle = jobTitle;
            _yearJoined = yearJoined;
            _payRate = payRate;

        }

        static Employee() => _CompanyName = "Rapido Pest Control";

        public string CompanyName {
            get { return _CompanyName; }
            set { _CompanyName = value; }

        }

        public string jobTitle {

            get { return _jobTitle; }
            set { _jobTitle = value;}
        
        }
        public int yearJoined {
            get { return _yearJoined; }
            set { _yearJoined = value; }
        }

        public decimal payRate 
        {
            get { return _payRate; }
            set { _payRate = value; }
        }


    }

    class PartTimer : Employee
    {
        int _weeklyHours;

        public PartTimer(int weeklyHours) : base(string.Empty, 0, 0)
        {
            _weeklyHours = weeklyHours;
        }

        public int weeklyHours
        { 
            get { return _weeklyHours; }
            set { _weeklyHours = value; }

        }


    }





}
