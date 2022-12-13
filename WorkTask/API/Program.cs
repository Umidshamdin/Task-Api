using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer;
using ServiceLayer.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Filters;
using ServiceLayer.Services.Interfaces;
using Microsoft.OpenApi.Models;
using ServiceLayer.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API;
using FluentValidation.AspNetCore;
using FluentValidation;
using ServiceLayer.Dtos.Employee;
using NLog;

var builder = WebApplication.CreateBuilder(args);

    LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/Nlog.config"));

    builder.Services.AddControllers();
    builder.Services.AddHttpLogging(logging => logging.LoggingFields= Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseBody);
    builder.Services.AddScoped<ILoggerService, LoggerService>();

    builder.Services.AddFluentValidation();
    builder.Services.AddLogging();
    builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
     .AddDefaultTokenProviders();

    builder.Services.Configure<IdentityOptions>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireDigit = true;
        options.User.RequireUniqueEmail = true;
        options.Lockout.MaxFailedAccessAttempts = 3;
        options.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(10);
        options.Lockout.AllowedForNewUsers = true;
    });

    builder.Services
        .AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ClockSkew = System.TimeSpan.Zero // remove delay of token when expire
            };
        });
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
    builder.Services.AddAutoMapper(typeof(MappingProfile));


    builder.Services.AddRepositoryLayer();
    builder.Services.AddServiceLayer();
    builder.Services.AddTransient<ITokenService, TokenService>();
    builder.Services.AddTransient<IValidator<EmployeeCreateDto>, EmployeeCreateValidator>();
    
    builder.Services.AddSwaggerGen(options =>
    {

        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });

    builder.Services.AddResponseCaching();
    var app = builder.Build();
    IWebHostEnvironment env = app.Environment;
    //logging using
    app.UseHttpLogging();
    //logging using
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT_ApiIdentity v1"));
    app.UseHttpsRedirection();
    app.UseMiddleware<RequestResponceMiddleware>();
    app.UseHttpLogging();
    app.UseResponseCaching();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();
