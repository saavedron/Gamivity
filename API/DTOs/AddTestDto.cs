using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTOs
{
    public class AddTestDto
    {

        public Test Test { get; set; }
        public string ClassName { get; set; }

    }
}