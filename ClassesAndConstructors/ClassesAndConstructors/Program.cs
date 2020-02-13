using System;

namespace ClassesAndConstructors
{
    class Program
    {
        static void Main(string[] args)
        {

            /// PRIVATE CLASS////////
            // If you uncomment the following statement, it will generate
            // an error because the constructor is inaccessible:
            // Counter aCounter = new Counter();   // Error
      

            Counter.currentCount = 100;
            Counter.IncrementCount();
            Console.WriteLine("New count: {0}", Counter.currentCount);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            /////////////////////////


            ///////COPY CONSTRUCTOR EXAMPLE//////////////////////////
            // Create a Person object by using the instance constructor.
            PersonCopy person1 = new PersonCopy("George", 40);

            // Create another Person object, copying person1.
            PersonCopy person2 = new PersonCopy(person1);

            // Change each person's age. 
            person1.Age = 39;
            person2.Age = 41;

            // Change person2's name.
            person2.Name = "Charles";

            // Show details to verify that the name and age fields are distinct.
            Console.WriteLine(person1.Details());
            Console.WriteLine(person2.Details());

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
            ////////////////////////////////////////////////////////
            

            Console.WriteLine("Start");
            PartTimer pt1 = new PartTimer(15);
            pt1.Forename = "Cliff";
            pt1.surname = "Hanger";
            pt1.jobTitle = "Master Rat Catcher";
            pt1.payRate = 500;
            pt1.yearJoined = 2015;
            pt1.CompanyName = "Acme Pest Control";

            Console.WriteLine($"{pt1.Forename} {pt1.surname} is contracted to work {pt1.weeklyHours} hours every week");
            Console.WriteLine($"For Company - {pt1.CompanyName}, as a {pt1.jobTitle} since {pt1.yearJoined} their pay rate is {pt1.payRate}");

            PartTimer pt2= new PartTimer(25);
            pt2.Forename = "Sally";
            pt2.surname = "Forth";
            pt2.jobTitle = "Fumigator/Exterminator";
            pt2.payRate = 1500;
            pt2.yearJoined = 2011;
            pt2.CompanyName = "Spray Away Inc";

            Console.WriteLine($"{pt2.Forename} {pt2.surname} are contracted to work {pt2.weeklyHours} hours every week");
            Console.WriteLine($"For Company - {pt2.CompanyName}, as a {pt2.jobTitle} since {pt2.yearJoined} their pay rate is {pt2.payRate}");

            // check the static company field and see whats happened:
            Console.WriteLine();
            Console.WriteLine($"Here are {pt1.Forename}'s details again, see who they work for now!");
            Console.WriteLine($"For Company - {pt1.CompanyName}, as a {pt1.jobTitle} since {pt1.yearJoined}, pay rate is {pt1.payRate}");
            Console.ReadKey();

        }
    }
}
