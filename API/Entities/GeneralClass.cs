namespace API.Entities
{
    public class GeneralClass
    {
        public int Id { get; set; }
        public int ClassLevel { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }


        public Class Class { get; set; }
        public int ClassId { get; set; }

    }
}