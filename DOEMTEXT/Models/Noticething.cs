using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 公告
/// </summary>
public partial class Noticething
{
    /// <summary>
    /// 公告标识（唯一）
    /// </summary>
    public int ThingId { get; set; }

    /// <summary>
    /// 公告内容
    /// </summary>
    public string NoticeText { get; set; } = null!;

    /// <summary>
    /// 发布人
    /// </summary>
    public string Release { get; set; } = null!;

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }
}
