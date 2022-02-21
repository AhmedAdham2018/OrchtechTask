namespace Api.DTOs
{
    public class StudentCreateDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Gender { get; set; }
        public string? Mobile { get; set; }
        public List<int> StudentClasses { get; set; } = null!;
    }
}
