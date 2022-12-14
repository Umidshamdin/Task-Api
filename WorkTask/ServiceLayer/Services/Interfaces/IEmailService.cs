using ServiceLayer.Dtos.AppUser;
using ServiceLayer.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IEmailService
    {
        Task ConfirmEmail(string userId, string token);
        void Register(RegisterDto registerDto, string link);
    }
}
