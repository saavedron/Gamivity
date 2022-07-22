using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Classes")]
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // public Student Student { get; set; }
        // public int StudentID { get; set; }

        public GeneralClass GeneralClass { get; set; }
        public int GeneralClassId { get; set; }
    }
}