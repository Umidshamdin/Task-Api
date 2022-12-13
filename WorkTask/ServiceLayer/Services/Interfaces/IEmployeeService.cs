using ServiceLayer.Dtos.AppUser;
using ServiceLayer.Dtos.Employee;

namespace ServiceLayer.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeListDto>> GetAllAsync();
        Task InsertAsync(EmployeeCreateDto employeeCreateDto);
        Task UpdateAsync(int id, EmployeeUpdateDto employeeUpdateDto);
        Task DeleteAsync(int id);
        Task<EmployeeListDto> GetAsync(int id);
        Task<IEnumerable<EmployeeListDto>> GetByNameAsync(string name);
    }
}
