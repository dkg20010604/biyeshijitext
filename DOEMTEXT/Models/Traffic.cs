using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 人员流动
/// </summary>
public partial class Traffic
{
    public int Id { get; set; }

    /// <summary>
    /// 身份证
    /// </summary>
    public string? Idcard { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    public string PhionNumber { get; set; } = null!;

    /// <summary>
    /// 进时间
    /// </summary>
    public DateTime? ComeTime { get; set; }

    /// <summary>
    /// 出时间
    /// </summary>
    public DateTime? OutTime { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdatedBy { get; set; }
}
