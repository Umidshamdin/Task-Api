using DomainLayer.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.JSInterop.Infrastructure;
using MimeKit;
using MimeKit.Text;
using ServiceLayer.Dtos.AppUser;
using ServiceLayer.Dtos.Employee;
using ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class EmailService : IEmailService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _accessor;
        private readonly LinkGenerator _generator;
        
        public EmailService(UserManager<AppUser> userManager, IWebHostEnvironment env, LinkGenerator generator, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _generator = generator;
            _accessor = accessor;
            _env = env;
        }
        public void Register(RegisterDto registerDto, string link)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test", "test12345678123456a@gmail.com"));
            message.To.Add(new MailboxAddress(registerDto.FullName, registerDto.Email));
            message.Subject = "Confirm Email";
            string emailbody = string.Empty;

            using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Confirm.html")))
            {
                emailbody = streamReader.ReadToEnd();
            }

            emailbody = emailbody.Replace("{{code}}", $"{link}").Replace("{{fullname}}", $"{registerDto.FullName}");
            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("test12345678123456a@gmail.com", "yhhhygmaghtfiwlk");
            smtp.Send(message);
            smtp.Disconnect(true);
        }
        public async Task ConfirmEmail(string userId, string token)
        {
            AppUser appUser = await _userManager.FindByIdAsync(userId);
          
            await _userManager.ConfirmEmailAsync(appUser, token);
        }
    }
}
