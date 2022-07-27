using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ClassTest
    {
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }

    }
}