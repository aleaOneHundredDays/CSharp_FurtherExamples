﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LibraryServiceSolution
{
 [DataContract]
    class Book
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set;}

    }
}
