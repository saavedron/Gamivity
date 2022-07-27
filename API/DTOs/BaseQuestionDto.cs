using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTOs
{
    public class BaseQuestionDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public string Feedback { get; set; }


    }
}