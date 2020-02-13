using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndConstructors
{
    class CopyConstructor
    {
    }


    class PersonCopy
    {
        // Copy constructor.
        public PersonCopy(PersonCopy previousPersonCopy)
        {
            Name = previousPersonCopy.Name;
            Age = previousPersonCopy.Age;
        }

        //// Alternate copy constructor calls the instance constructor.
        //public PersonCopyCopy(PersonCopyCopy previousPersonCopy)
        //    : this(previousPersonCopy.Name, previousPersonCopy.Age)
        //{
        //}

        // Instance constructor.
        public PersonCopy(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public string Details()
        {
            return Name + " is " + Age.ToString();
        }
    }


}
