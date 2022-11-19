using AutoMapper;
using DOEMTEXT.Context;
using DOEMTEXT.DTO;
using DOEMTEXT.DTO.APIHelp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DOEMTEXT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginJwtController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly StudentContext _context;
        private readonly IMapper _mapper;
        public LoginJwtController(IConfiguration configuration,StudentContext context,IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("Login")]
        public APIHelp<string> Login([FromBody] LoginInfo login)
        {
            APIHelp<string> help = new APIHelp<string>();
            //查询操作

            //通过:学生
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,login.name),
                new Claim("Nomal_Student","true")
            };
            //通过：老师
            var signingAlgorithm = SecurityAlgorithms.HmacSha256;
            var secretByte = Encoding.UTF8.GetBytes(_configuration["Authentication:JwtPassword"]);
            var signingKey = new SymmetricSecurityKey(secretByte);
            var signingCredentials = new SigningCredentials(signingKey, signingAlgorithm);
                                                                                           
            var token = new JwtSecurityToken(
               issuer: _configuration["Authentication:Admin"],//谁发布的
               audience: _configuration["Authentication:User"],//发布给谁用
               claims: claims,//payload数据
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
