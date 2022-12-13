using DomainLayer.Common;
using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Entities
{
    public class Employee : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

    }
}
