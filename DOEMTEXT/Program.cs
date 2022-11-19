using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using DOEMTEXT.DTO.AUTOMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DOEMTEXT
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            builder.Services.AddDbContext<Context.StudentContext>();

            //使用Auto mapper
            builder.Services.AddAutoMapper(
                typeof(StudentMapper),
                typeof(LiveInfoMapper),
                typeof(DiskeepInfoMapper),
                typeof(CollegeMapper),
                typeof(BaseClassInfoMapper),
                typeof(DetailedClassInfoMapper));
            //允许跨域请求
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("allow_all", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            //配置Jwt认证服务
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>//配置jwtBearer
                {
                    var secretByte = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtPassword"]);
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {

                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["Authentication:Admin"],

                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["Authentication:User"],

                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(secretByte)
                    };
                });
            //配置使用者身份
            builder.Services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("Nomal_Student", policy => policy.RequireClaim("NomalStudent"));
                    options.AddPolicy("College_inspect", policy => policy.RequireClaim("College_inspect"));
                    options.AddPolicy("Scool_inspect", policy => policy.RequireClaim("Scool_inspect"));
                    options.AddPolicy("Instructor", policy => policy.RequireClaim("Instructor"));
                    options.AddPolicy("Headmaster", policy => policy.RequireClaim("Headmaster"));
                    options.AddPolicy("College_manager", policy => policy.RequireClaim("College_manager"));
                    options.AddPolicy("Root_admin", policy => policy.RequireClaim("Root_admin"));
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseCors("allow_all");

            app.MapControllers();

            app.Run();
        }
    }
}