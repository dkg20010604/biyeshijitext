using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 详细班级信息
/// </summary>
public partial class DetailedClassInfo
{
    public int Id { get; set; }

    /// <summary>
    /// 班级代码
    /// </summary>
    public string ClassId { get; set; } = null!;

    /// <summary>
    /// 年级
    /// </summary>
    public int Grade { get; set; }

    /// <summary>
    /// 班级
    /// </summary>
    public int Class { get; set; }

    /// <summary>
    /// 本/专科
    /// </summary>
    public string Nature { get; set; } = null!;

    /// <summary>
    /// 附加描述
    /// </summary>
    public string? Additional { get; set; }

    /// <summary>
    /// 班主任
    /// </summary>
    public string Headmaster { get; set; } = null!;

    /// <summary>
    /// 辅导员
    /// </summary>
    public string Instructor { get; set; } = null!;

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    public virtual BaseClassInfo? ClassNavigation { get; set; } = null!;

    public virtual Teacher? HeadmasterNavigation { get; set; } = null!;

    public virtual Teacher? InstructorNavigation { get; set; } = null!;

    public virtual ICollection<StudentsInfo>? StudentsInfos { get; } = new List<StudentsInfo>();
}
