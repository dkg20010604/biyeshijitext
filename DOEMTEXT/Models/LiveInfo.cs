using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 居住信息
/// </summary>
public partial class LiveInfo
{
    /// <summary>
    /// 学号
    /// </summary>
    public string StudentId { get; set; } = null!;

    /// <summary>
    /// 房间标识
    /// </summary>
    public int RoomId { get; set; }

    /// <summary>
    /// 床号
    /// </summary>
    public int BedId { get; set; }

    /// <summary>
    /// 宿舍角色
    /// </summary>
    public bool Role { get; set; }

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    public virtual RoomInfo Room { get; set; } = null!;

    public virtual StudentsInfo? StudentsInfo { get; set; }
}
