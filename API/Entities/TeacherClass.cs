using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class TeacherClass
    {
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }

    }
}