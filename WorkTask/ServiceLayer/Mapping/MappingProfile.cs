using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.Dtos.AppUser;
using ServiceLayer.Dtos.Employee;


namespace ServiceLayer.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeListDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }
    }
}
