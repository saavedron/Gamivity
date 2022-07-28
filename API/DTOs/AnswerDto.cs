using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public bool IsRight { get; set; }
    }
}