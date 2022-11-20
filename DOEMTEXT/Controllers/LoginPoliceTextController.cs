using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOEMTEXT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginPoliceTextController : ControllerBase
    {

        [HttpGet("OnlyStudent")]
        [Authorize(Policy = "Nomal_Student")]
        public string Get()
        {
            return "所有学生可见";
        }


        [HttpGet("OnlyCollege")]
        [Authorize(Policy = "College_inspect")]
        public string Get1()
        {
            return "仅院级宿检部可见";
        }


        [HttpGet("OnlyScool")]
        [Authorize(Policy = "Scool_inspect")]
        public string Get2()
        {
            return "仅校级宿检部可见";
        }


        [HttpGet("OnlyTeacher")]
        [Authorize(Policy = "Instructor")]
        public string Get3()
        {
            return "辅导员和班主任都可见";
        }


        [HttpGet("CollegeTeacher")]
        [Authorize(Policy = "College_manager")]
        public string Get4()
        {
            return "仅院级管理员可见";
        }


        [HttpGet("Root")]
        [Authorize(Policy = "Root_admin")]
        public string Get5()
        {
            return "仅超级管理员可见";
        }
    }
}
