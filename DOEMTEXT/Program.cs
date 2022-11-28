using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using DOEMTEXT.DTO.AUTOMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.SignalR;
using DOEMTEXT.Hubs;
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
            builder.Services.AddSignalR();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebSystem", Version = "v1" });
                #region Swagger使用鉴权组件
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "直接在下框中输入Bearer {token}（注意两者之间是一个空格）",
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
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            builder.Services.AddDbContext<Context.StudentContext>();
            #region 使用Auto mapper
            builder.Services.AddAutoMapper(
                typeof(StudentMapper),
                typeof(LiveInfoMapper),
                typeof(DiskeepInfoMapper),
                typeof(CollegeMapper),
                typeof(BaseClassInfoMapper),
                typeof(DetailedClassInfoMapper));
            #endregion
            #region 允许跨域请求
            builder.Services.AddCors(options =>
                        {
                            options.AddPolicy("SignalR", builder =>
                            {
                                builder
                                .AllowCredentials()
                                .WithOrigins("http://10.40.6.62:8080/")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .SetIsOriginAllowed(s => true);
                            });
                        });
            #endregion
            //配置Jwt认证服务
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>//配置jwtBearer
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
            //配置使用者身份
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
                //app.UseDefaultFiles();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("SignalR");
            app.MapControllers();
            app.MapHub<ChatHub>("/chathub");
            app.MapHub<GroupHub>("/grouphub");
            app.Run();
        }
    }
}