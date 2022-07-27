using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class TestQuestion
    {
        public int Id { get; set; }
        public int TimeToFinish { get; set; } //change
        public BaseQuestion BaseQuestion { get; set; }
        public int BaseQuestionId { get; set; }

    }
}