using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("Points")]
    public class Point
    {
        public int Id { get; set; }
        public int Gamipoints { get; set; }
        public int GamiXP { get; set; }
        public int Gamilevel { get; set; }
        public int Gamicoins { get; set; }

    }
}