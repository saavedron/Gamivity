using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("BaseQuestions")]
    public class BaseQuestion
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public string Feedback { get; set; }

        public GeneralClass GeneralClass { get; set; }
        public int GeneralClassId { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; set; }
    }
}