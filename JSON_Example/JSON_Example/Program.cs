
using System;
using System.IO;
using System.Web.Helpers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace JSON_Example
{
    class Program
    {

        public class Lad
        {
            public string firstName;
            public string lastName;
        }

        static void Main(string[] args)
        {
   

        var obj = new Lad
            {
                firstName = "Markoff",
                lastName = "Chaney"
               
            };

            Lad lad1 = (Lad)obj;

            var options1 = new JsonSerializerOptions
            {
                WriteIndented = true,
            };





            //var json = new 
            //Console.WriteLine(json);



            // Basic OBject
            Product product = new Product();

            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99M;
            product.Sizes = new string[] { "Small", "Medium", "Large" };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            //var json = new JsonSerializer();
            ////Console.WriteLine(json);

            string output = JsonSerializer.Serialize(product,options);
            Console.WriteLine(output);

            Product deserializedProduct = JsonSerializer.Deserialize<Product>(output);


            Employee emp = new Employee();
            EmployeeData empData = new EmployeeData();
            emp = empData.EmployeeDataOps();

             string JSONresult = JsonSerializer.Serialize(emp);

            string path = @"C:\_Angela\_GIT_CSharp\MiscTextFiles\employee.json";

            if (File.Exists(path))
            {
                File.Delete(path);        
            }

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                tw.Close();
            }

            string[] subjectsTaken = new string[4] { "Biology", "Maths", "History", "Chemistry" };

            Student stu = new Student();
            stu.Name = "Andrew Hill";
            stu.Class = 345;
            stu.RollNo = 100345;
            stu.Subjects = subjectsTaken;

            JSONresult = JsonSerializer.Serialize(stu);

            path = @"C:\_Angela\_GIT_CSharp\MiscTextFiles\student.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                tw.Close();
            }

    
        }
    }
    [DataContract]
    internal class Product
    {
    [DataMember]
       public String Name;
        [DataMember]
        public DateTime ExpiryDate;
        [DataMember]
        public Decimal Price;
        [DataMember]
        public string[] Sizes; 
    }
}
