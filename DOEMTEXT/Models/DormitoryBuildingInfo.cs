using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 宿舍楼信息
/// </summary>
public partial class DormitoryBuildingInfo
{
    /// <summary>
    /// 楼号
    /// </summary>
    public int BuildId { get; set; }

    /// <summary>
    /// 楼层数
    /// </summary>
    public int BuildFloors { get; set; }

    /// <summary>
    /// 每层房间数
    /// </summary>
    public int FloorRoomNumber { get; set; }

    /// <summary>
    /// 房间床数
    /// </summary>
    public int RoomBed { get; set; }

    /// <summary>
    /// 管理人员
    /// </summary>
    public string? ManageId { get; set; }

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    public virtual Teacher? Manage { get; set; }

    public virtual ICollection<RoomInfo> RoomInfos { get; } = new List<RoomInfo>();
}
