using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("GeneralClasses")]
    public class GeneralClass
    {
        public int Id { get; set; }
        public int ClassLevel { get; set; }
        public string GeneralClassName { get; set; }
        public string Course { get; set; }

        public ICollection<Class> Classes { get; set; }
        public ICollection<BaseQuestion> BaseQuestions { get; set; }


    }
}