using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 违纪记录
/// </summary>
public partial class Diskeep
{
    public int Id { get; set; }

    /// <summary>
    /// 学号
    /// </summary>
    public string StudentId { get; set; } = null!;

    /// <summary>
    /// 违规类型
    /// </summary>
    public string DiskeepType { get; set; } = null!;

    /// <summary>
    /// 违规时间
    /// </summary>
    public DateTime DiskeepTime { get; set; }

    /// <summary>
    /// 违规描述
    /// </summary>
    public string DiskeepText { get; set; } = null!;

    /// <summary>
    /// 更新人
    /// </summary>
    public string UpdatedBy { get; set; } = null!;

    public virtual StudentsInfo Student { get; set; } = null!;
}
