using AutoMapper;
using DOEMTEXT.Context;
using DOEMTEXT.DTO;
using DOEMTEXT.DTO.APIHelp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Packaging;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZSpitz.Util;

namespace DOEMTEXT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginJwtController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly StudentContext _context;
        private readonly IMapper _mapper;
        public LoginJwtController(IConfiguration configuration, StudentContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public APIHelp<string> Login([FromBody] LoginInfo login)
        {
            //查询操作
            //do something
            //完成，得到权限等信息(测试直接将登录名输入为权限名)
            Claim[] claims;
            //普通学生
            if (login.name == "Nomal_Student")
            {
                claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,login.password),
                    new Claim("Nomal_Student","true")
                };
            }
            //院级宿检部
            else if (login.name == "College_inspect")
            {
                claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,login.password),
                    new Claim("Nomal_Student","true"),
                    new Claim("College_inspect","true")
                };
            }
            else if (login.name == "Scool_inspect")
            {
                claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,login.password),
                    new Claim("Nomal_Student","true"),
                    new Claim("Scool_inspect","true")
                };
            }
            //普通老师
            else if (login.name == "Instructor" || login.name == "Headmaster")
            {
                claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,login.password),
                    new Claim("Instructor","true"),
                    new Claim("Headmaster","true")
                };
            }
            else if (login.name == "College_manager")
            {
                claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,login.password),
                    new Claim("Instructor","true"),
                    new Claim("Headmaster","true"),
                    new Claim("College_manager","true")
                };
            }
            else if (login.name == "Root_admin")
            {
                claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,login.password),
                    new Claim("Instructor","true"),
                    new Claim("Headmaster","true"),
                    new Claim("College_manager","true"),
                    new Claim("Root_admin","true")
                };
            }
            else
            {
                return new APIHelp<string>()
                {
                    code = 400,
                    Messege = "输入有误"
                };
            }
            var signingAlgorithm = SecurityAlgorithms.HmacSha256;
            var secretByte = Encoding.UTF8.GetBytes(_configuration["Authentication:JwtPassword"]);
            var signingKey = new SymmetricSecurityKey(secretByte);
            var signingCredentials = new SigningCredentials(signingKey, signingAlgorithm);

            var token = new JwtSecurityToken(
               issuer: _configuration["Authentication:Admin"],//发布者
               audience: _configuration["Authentication:User"],//使用者
               claims: claims,//基础数据
               notBefore: DateTime.UtcNow,//发布时间
               expires: DateTime.UtcNow.AddDays(10),//有效期10天
               signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
               );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            //3、返回200 OK，回传jwt
            return new APIHelp<string>()
            {
                code = 200,
                Messege = "登陆成功",
                Data = tokenString

            };

        }
    }
}
