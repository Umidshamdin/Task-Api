using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dtos.AppUser;
using ServiceLayer.Services.Interfaces;
using System;
using static API.Utilities.Helper;

namespace API.Controllers
{
    public class AccountController:BaseController
    {
        private readonly IAccountService _service;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IAccountService service, IWebHostEnvironment env, UserManager<AppUser> userManager, IEmailService emailService, RoleManager<IdentityRole> roleManager)
        {
            _service = service;
            _env = env;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            await _service.Register(registerDto);
            AppUser appUser = await _userManager.FindByEmailAsync(registerDto.Email);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var link = Url.Action(nameof(ConfirmEmail), "Account", new { userId = appUser.Id, token = code }, Request.Scheme, Request.Host.ToString());
            if(link!= null)
            {
                _emailService.Register(registerDto, link);
            }


            return Ok();

        }

        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            await _service.ConfirmEmail(userId, token);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<string> Login([FromBody] LoginDto loginDto)
        {
            return await _service.Login(loginDto);
        }

        //[HttpPost]
        //[Route("Role")]
        //public async Task CreateRole()
        //{
        //    foreach (var role in Enum.GetValues(typeof(UserRoles)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(role.ToString()))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
        //        }
        //    }
        //}
    }
}
