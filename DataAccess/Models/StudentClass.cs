namespace DataAccess.Models
{
    public class StudentClass : BaseEntity
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int ClassId { get; set; }
        public Class? Class { get; set; }
    }
}
