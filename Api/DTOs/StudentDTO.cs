using DataAccess.Models;

namespace Api.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Gender { get; set; }
        public string? Mobile { get; set; }

        public IEnumerable<Class> StudentClasses { get; set; } = Enumerable.Empty<Class>();

    }
}
