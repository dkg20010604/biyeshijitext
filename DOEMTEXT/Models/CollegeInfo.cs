using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 学院信息
/// </summary>
public partial class CollegeInfo
{
    /// <summary>
    /// 学院代码
    /// </summary>
    public string CollegeId { get; set; } = null!;

    /// <summary>
    /// 学院名称
    /// </summary>
    public string CollegeName { get; set; } = null!;

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    public virtual ICollection<StudentsInfo> StudentsInfos { get; } = new List<StudentsInfo>();
}
