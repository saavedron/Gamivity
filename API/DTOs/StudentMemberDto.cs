using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTOs
{
    public class StudentMemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Name { get; set; }

        public ICollection<StudentClass> StudentClasses { get; set; }
    }
}