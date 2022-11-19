using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 过往成绩
/// </summary>
public partial class ScoreOld
{
    /// <summary>
    /// 房间标识
    /// </summary>
    public int? RoomId { get; set; }

    /// <summary>
    /// 房间分数
    /// </summary>
    public decimal RoomScore { get; set; }

    /// <summary>
    /// 年;yyyyy-0/1
    /// </summary>
    public string YearTerm { get; set; } = null!;
}
