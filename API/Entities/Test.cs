using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public int Gamipoints { get; set; }
      
        public ICollection<TestQuestion> TestQuestions { get; set; }
    }
}