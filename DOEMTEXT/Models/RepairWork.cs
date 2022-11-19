using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 维修事务
/// </summary>
public partial class RepairWork
{
    /// <summary>
    /// 事件标识
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 提交人学号/工号
    /// </summary>
    public string StudentId { get; set; } = null!;

    /// <summary>
    /// 详细信息
    /// </summary>
    public string DetailedInformation { get; set; } = null!;

    /// <summary>
    /// 事件状态
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// 当前处理人
    /// </summary>
    public string Handled { get; set; } = null!;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }
}
