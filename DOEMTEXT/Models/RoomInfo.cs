using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 宿舍房间信息
/// </summary>
public partial class RoomInfo
{
    /// <summary>
    /// 房间标识
    /// </summary>
    public int RoomId { get; set; }

    /// <summary>
    /// 楼号
    /// </summary>
    public int BuildId { get; set; }

    /// <summary>
    /// 房间号 : 楼层房间号
    /// </summary>
    public int RoomNumber { get; set; }

    /// <summary>
    /// 床数
    /// </summary>
    public int BedNumber { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string State { get; set; } = null!;

    /// <summary>
    /// 电费
    /// </summary>
    public decimal? ElectricityFees { get; set; }

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    public virtual DormitoryBuildingInfo Build { get; set; } = null!;

    public virtual ICollection<LiveInfo> LiveInfos { get; } = new List<LiveInfo>();
}
