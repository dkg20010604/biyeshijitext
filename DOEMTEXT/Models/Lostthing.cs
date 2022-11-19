using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 失物招领信息
/// </summary>
public partial class Lostthing
{
    /// <summary>
    /// 标识
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 上交人员
    /// </summary>
    public string UpPerson { get; set; } = null!;

    /// <summary>
    /// 申领人员
    /// </summary>
    public string DownPerson { get; set; } = null!;

    /// <summary>
    /// 失物信息
    /// </summary>
    public string LostText { get; set; } = null!;

    /// <summary>
    /// 提交时间
    /// </summary>
    public DateTime UpTime { get; set; }

    /// <summary>
    /// 申领时间
    /// </summary>
    public DateTime? DownTime { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdatedBy { get; set; }
}
