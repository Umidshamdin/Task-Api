using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(e => e.LastName).IsRequired();
            builder.Property(e => e.Age).IsRequired();
            builder.Property(e => e.PhoneNumber).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.SoftDelete).IsRequired();
            builder.Property(e => e.CreateTime).IsRequired();          
        }
    }
}
