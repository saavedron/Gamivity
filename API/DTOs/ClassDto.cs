using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTOs
{
    public class ClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // public Student Student { get; set; }
        // public int StudentID { get; set; }

        public GeneralClass GeneralClass { get; set; }
    }
}