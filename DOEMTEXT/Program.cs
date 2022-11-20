using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using DOEMTEXT.DTO.AUTOMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebSystem", Version = "v1" });
                #region Swaggerʹ�ü�Ȩ���
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                                {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                                }
                        },
                        new string[] {}
                    }
                        });
                #endregion
            });
            builder.Services.AddSignalR();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            builder.Services.AddDbContext<Context.StudentContext>();

            //ʹ��Auto mapper
            builder.Services.AddAutoMapper(
                typeof(StudentMapper),
                typeof(LiveInfoMapper),
                typeof(DiskeepInfoMapper),
                typeof(CollegeMapper),
                typeof(BaseClassInfoMapper),
                typeof(DetailedClassInfoMapper));
            //�����������
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

            //����Jwt��֤����
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>//����jwtBearer
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["Authentication:Admin"],

                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["Authentication:User"],

                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtPassword"]))
                    };
                });
            //����ʹ�������
            builder.Services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("Base_power", policy => policy.RequireClaim("Base_power"));
                    options.AddPolicy("Nomal_Student", policy => policy.RequireClaim("Nomal_Student"));
                    options.AddPolicy("College_inspect", policy => policy.RequireClaim("College_inspect"));
                    options.AddPolicy("Scool_inspect", policy => policy.RequireClaim("Scool_inspect"));
                    options.AddPolicy("Instructor", policy => policy.RequireClaim("Instructor"));
                    options.AddPolicy("Headmaster", policy => policy.RequireClaim("Headmaster"));
                    options.AddPolicy("College_manager", policy => policy.RequireClaim("College_manager"));
                    options.AddPolicy("Root_admin", policy => policy.RequireClaim("Root_admin"));
                    //Console.WriteLine(options.ToString());
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("allow_all");

            app.MapControllers();

            app.Run();
        }
    }
}