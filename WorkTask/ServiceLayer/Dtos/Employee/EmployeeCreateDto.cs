using FluentValidation;

namespace ServiceLayer.Dtos.Employee
{
    public class EmployeeCreateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }

    public class EmployeeCreateValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateValidator()
        {
            RuleFor(m => m.FirstName).NotEmpty().WithMessage("Pleace add FirstName");
            RuleFor(m => m.LastName).NotEmpty().WithMessage("Pleace add LastName");
            RuleFor(m => m.Age).NotEmpty().WithMessage("Pleace add age");
            RuleFor(m => m.PhoneNumber).NotEmpty().WithMessage("Pleace add PhoneNumber");
            RuleFor(m => m.Email).EmailAddress().WithMessage("Pleace add emailAddress");
        }
    }
}
