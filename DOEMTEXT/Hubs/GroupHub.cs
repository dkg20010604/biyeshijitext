using DOEMTEXT.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
namespace DOEMTEXT.Hubs
{
    public class GroupHub : Hub
    {
        private readonly StudentContext _context;
        public GroupHub(StudentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 加入分组
        /// </summary>
        /// <param name="UserID">用户标识</param>
        /// <returns></returns>
        public async Task JoinGroup(string UserID)
        {
            var info = await _context.StudentsInfos.FindAsync(UserID);
            if (info != null)
            {
                var b = await _context.LiveInfos.Include(p => p.Room).Where(s => s.StudentId == UserID).FirstOrDefaultAsync();
                await Groups.AddToGroupAsync(Context.ConnectionId, "Class" + info.Id.ToString());
                await Groups.AddToGroupAsync(Context.ConnectionId, "College" + info.CollegeId.ToString());
                await Groups.AddToGroupAsync(Context.ConnectionId, "Build" + b.Room.BuildId.ToString());
                if (info.Power == "College_inspect")
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, info.Power + info.CollegeId.ToString());
                }
                else if (info.Power == "Scool_inspect")
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, "Scool_inspect");
                }
            }
            else
            {

            }

        }

        /// <summary>
        /// 移除分组
        /// </summary>
        /// <param name="GroupName">组名</param>
        /// <returns></returns>
        public async Task RemoveGroup(string GroupName) => await Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupName);

        /// <summary>
        /// 向特定组发送信息
        /// </summary>
        /// <param name="GroupName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task GroupMessage(List<string> GroupsName, string data) => await Clients.Groups(GroupsName).SendAsync("SendGroup", data);

    }
}
