using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 老师/宿管信息
/// </summary>
public partial class Teacher
{
    /// <summary>
    /// 同工号
    /// </summary>
    public string AdministeredId { get; set; } = null!;

    /// <summary>
    /// 登陆密码
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// 姓名
    /// </summary>
    public string AdminName { get; set; } = null!;

    /// <summary>
    /// 手机号
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// 权限
    /// </summary>
    public string Powers { get; set; } = null!;

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    public virtual ICollection<DetailedClassInfo> DetailedClassInfoHeadmasterNavigations { get; } = new List<DetailedClassInfo>();

    public virtual ICollection<DetailedClassInfo> DetailedClassInfoInstructorNavigations { get; } = new List<DetailedClassInfo>();

    public virtual ICollection<DormitoryBuildingInfo> DormitoryBuildingInfos { get; } = new List<DormitoryBuildingInfo>();
}
