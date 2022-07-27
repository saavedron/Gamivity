using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("Answers")]
    public class Answer
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public bool IsRight { get; set; }
        public BaseQuestion Question { get; set; }
        public int BaseQuestionId { get; set; }


    }
}