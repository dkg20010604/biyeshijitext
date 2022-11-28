using DOEMTEXT.Context;
using DOEMTEXT.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DOEMTEXT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRGroupsController : ControllerBase
    {
        private readonly IHubContext<GroupHub> _hubContext;
        private readonly StudentContext _context;
        public SignalRGroupsController(IHubContext<GroupHub> hubContext, StudentContext context)
        {
            _hubContext = hubContext;
            _context = context;
        }

        /// <summary>
        /// 将用户加入分组
        /// </summary>
        /// <param name="name">用户标识</param>
        /// <returns></returns>
        [HttpPost("Setgroup")]
        public async Task SetGroup(string name)
        {
            var info = await _context.StudentsInfos.FindAsync(name);
        }
    }
}
