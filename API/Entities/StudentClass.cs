using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class StudentClass
    {
        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Class Class { get; set; }
        public int ClassId { get; set; }

    }
}