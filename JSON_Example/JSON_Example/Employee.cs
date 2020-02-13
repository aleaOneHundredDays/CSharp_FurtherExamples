using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Example
{
    class Employee
    {
        public string FirstName = "Sam";
        public string LastName = "Jackson";
        public int employeeID;
        public string Designation = "Manager";
        public string[] KnownLanguages = { "C#", "Java", "Perl" };

    }

    class EmployeeData
    {
        

        public Employee EmployeeDataOps()
        {
            int locationCode = 569;
            int employeeNumber = 8523;
            int empID = int.Parse(locationCode.ToString() + employeeNumber.ToString());
            Employee empObj = new Employee();
            return empObj;

        }

    }
}
