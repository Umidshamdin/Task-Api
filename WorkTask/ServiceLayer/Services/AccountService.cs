using AutoMapper;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using ServiceLayer.Dtos.AppUser;
using ServiceLayer.Dtos.Employee;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly AppDbContext _context;

        public AccountService(UserManager<AppUser> userManager, IMapper mapper,ITokenService tokenService,IEmailService emailService,AppDbContext context)
        {
            _emailService= emailService;
            _userManager= userManager;
            _mapper= mapper;
            _tokenService= tokenService;
            _context = context;
        }
        public async Task Register(RegisterDto registerDto)
        {
            var user = _mapper.Map<AppUser>(registerDto);
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            await _userManager.AddToRoleAsync(user, "User");
        }
        public async Task ConfirmEmail(string userId, string token)
        {
            await _emailService.ConfirmEmail(userId, token);
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) return null;

            var roles = await _userManager.GetRolesAsync(user);

            if(user.EmailConfirmed==true)
            {  
                string token = _tokenService.GenerateJwtToken(user.Id, user.Email, user.UserName, (List<string>)roles);
                return token;
            }
            return "Emaili tesdiqleyin";
     
        }
        //public async Task<UserDto> GetUserByEmailAsync(string email)
        //{
        //    var appuser = await _userManager.FindByEmailAsync(email);
        //    var user = _mapper.Map<UserDto>(appuser);
        //    return user;
        //}

        //public Task<List<UserDto>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
