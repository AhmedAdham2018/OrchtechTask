
namespace DataAccess.Models
{
    public class Student : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Gender { get; set; }
        public string? Mobile { get; set; }

    }
}
