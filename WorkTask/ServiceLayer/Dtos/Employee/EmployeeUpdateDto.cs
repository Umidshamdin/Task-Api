
namespace ServiceLayer.Dtos.Employee
{
    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
