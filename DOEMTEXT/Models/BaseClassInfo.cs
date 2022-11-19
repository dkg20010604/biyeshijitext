using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 基本班级信息
/// </summary>
public partial class BaseClassInfo
{
    /// <summary>
    /// 班级代码
    /// </summary>
    public string ClassId { get; set; } = null!;

    /// <summary>
    /// 班级名称
    /// </summary>
    public string ClassName { get; set; } = null!;

    /// <summary>
    /// 学院代码
    /// </summary>
    public string CollegeId { get; set; } = null!;

    /// <summary>
    /// 状态（是否启用）
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    public virtual ICollection<DetailedClassInfo> DetailedClassInfos { get; } = new List<DetailedClassInfo>();
}
