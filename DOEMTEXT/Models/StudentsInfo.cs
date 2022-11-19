using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 学生信息
/// </summary>
public partial class StudentsInfo
{
    /// <summary>
    /// 学号
    /// </summary>
    public string StudentId { get; set; } = null!;

    /// <summary>
    /// 姓名
    /// </summary>
    public string StudentName { get; set; } = null!;

    /// <summary>
    /// 性别
    /// </summary>
    public bool Gender { get; set; }

    /// <summary>
    /// 身份证
    /// </summary>
    public string IdentityCard { get; set; } = null!;

    /// <summary>
    /// 学院代码
    /// </summary>
    public string CollegeId { get; set; } = null!;

    /// <summary>
    /// 详细班级代码
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// 密码
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// 权限
    /// </summary>
    public string Power { get; set; } = null!;

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    public virtual CollegeInfo College { get; set; } = null!;

    public virtual ICollection<Diskeep> Diskeeps { get; } = new List<Diskeep>();

    public virtual DetailedClassInfo IdNavigation { get; set; } = null!;

    public virtual LiveInfo Student { get; set; } = null!;
}
