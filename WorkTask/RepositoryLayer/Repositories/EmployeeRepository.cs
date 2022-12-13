using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Interfaces;

namespace RepositoryLayer.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {   
        public EmployeeRepository(AppDbContext context) : base(context)
        {
           
        }
    }
}
