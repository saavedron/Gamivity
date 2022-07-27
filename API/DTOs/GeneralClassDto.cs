using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class GeneralClassDto
    {
        public int Id { get; set; }
        public int ClassLevel { get; set; }
        public string GeneralClassName { get; set; }
        public string Course { get; set; }

    }
}