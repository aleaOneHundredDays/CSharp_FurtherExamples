using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
   public class ClassA
    {
        public int PropertyA { get; set; }
        private string aString;

        


    }

     class ClassB : ClassA
    {
        private int intB;
        static int staticIntB;

        public ClassB(int setInt)
        {
            intB = setInt;
            
        }

    }
}
