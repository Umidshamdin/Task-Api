using AutoMapper;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using RepositoryLayer;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.Dtos.AppUser;
using ServiceLayer.Dtos.Employee;
using ServiceLayer.Services.Interfaces;


namespace ServiceLayer.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            await _repository.DeleteAsync(model);
        }

        public async Task<List<EmployeeListDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            return _mapper.Map<List<EmployeeListDto>>(model);
        }

        public async Task<EmployeeListDto> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var result = _mapper.Map<EmployeeListDto>(model);
            return result;
        }
        public async Task InsertAsync(EmployeeCreateDto employeeCreateDto)
        {
            try
            {
                var model = _mapper.Map<Employee>(employeeCreateDto);
                await _repository.CreateAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
      
        }
        public async Task UpdateAsync(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            var entity = await _repository.GetAsync(id);
            _mapper.Map(employeeUpdateDto, entity);
            await _repository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<EmployeeListDto>> GetByNameAsync(string search)
        {
            return _mapper.Map<IEnumerable<EmployeeListDto>>(await _repository.FindAsync(m => m.FirstName.Contains(search)));
        }       
    }
}
