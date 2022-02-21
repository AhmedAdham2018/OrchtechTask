namespace Api.DTOs
{
    public class StudentUpdateDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Gender { get; set; }
        public string? Mobile { get; set; }
    }
}
