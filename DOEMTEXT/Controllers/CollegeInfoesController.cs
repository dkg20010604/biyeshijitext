using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOEMTEXT.Context;
using DOEMTEXT.Models;
using AutoMapper;
using DOEMTEXT.DTO.ModelsDTO;
using DOEMTEXT.DTO.APIHelp;
using System.Collections.Generic;
using System.Linq;
using static DOEMTEXT.DTO.ExpressionExtension<DOEMTEXT.Models.CollegeInfo>;
using DOEMTEXT.DTO;
using Microsoft.AspNetCore.SignalR;
using DOEMTEXT.Hubs;
using Microsoft.AspNetCore.Authorization;

namespace DOEMTEXT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeInfoesController : ControllerBase
    {
        private readonly StudentContext _Context;
        private readonly IMapper _IMapper;
        private readonly IHubContext<ChatHub> _HubClients;
        IHubContext<GroupHub> _Grouphub;
        public CollegeInfoesController(IHubContext<GroupHub> Grouphub, StudentContext context, IMapper mapper, IHubContext<ChatHub> hubClients)
        {
            _Context = context;
            _IMapper = mapper;
            _HubClients = hubClients;
            _Grouphub = Grouphub;
        }
        [HttpPost("AddCollege")]
        [AllowAnonymous]
        public async Task<APIHelp<CollegeInfomation>> AddCollege([FromBody] CollegeInfomation infomation)
        {
            if (_Context.CollegeInfos.Find(infomation.CollegeId) != null)
                return new APIHelp<CollegeInfomation>()
                {
                    code = 400,
                    Messege = "主键重复",
                    Data = _IMapper.Map<CollegeInfomation>(_Context.CollegeInfos.Find(infomation.CollegeId))
                };
            await _Context.CollegeInfos.AddAsync(new CollegeInfo()
            {
                CollegeId = infomation.CollegeId,
                CollegeName = infomation.CollegeName,
            });
            try
            {
                _Context.SaveChanges();

            }
            catch
            {
                return new APIHelp<CollegeInfomation>()
                {
                    code = 400,
                    Messege = "未知错误"
                };
            }
            await _HubClients.Clients.All.SendAsync("SendMsg", infomation);
            return new APIHelp<CollegeInfomation>()
            {
                code = 200,
                Messege = "成功添加",
                Data = infomation
            };
        }
        // GET: api/CollegeInfoes
        [HttpGet]
        public async Task<List<CollegeInfomation>> GetCollegeInfos()
        {
            var list = await _Context.CollegeInfos.ToListAsync();
            var collegelist = _IMapper.Map<List<CollegeInfomation>>(list);
            await _HubClients.Clients.All.SendAsync("ReceiveMessage", "my", "ds");

            await _Grouphub.Clients.Group("Nomal_Student").SendAsync("SendGroupMessage", "这是向全体学生发送的消息");
            return collegelist;
        }

        [HttpPost]
        public async Task<List<CollegeInfomation>> GetCollegeInfos([FromServices] IMapper mapper, List<QueryEntity>? queryEntities)
        {
            var data = await _Context.CollegeInfos.Where(ExpressionSplice(queryEntities)).ToListAsync();
            return mapper.Map<List<CollegeInfomation>>(data);
        }


        // DELETE: api/CollegeInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollegeInfo(string id)
        {
            var collegeInfo = await _Context.CollegeInfos.FindAsync(id);
            if (collegeInfo == null)
            {
                return NotFound();
            }

            _Context.CollegeInfos.Remove(collegeInfo);
            await _Context.SaveChangesAsync();

            return NoContent();
        }
    }
}
