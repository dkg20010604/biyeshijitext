using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

/// <summary>
/// 查寝分数
/// </summary>
public partial class Score
{
    /// <summary>
    /// 房间标识
    /// </summary>
    public int RoomId { get; set; }

    /// <summary>
    /// 房间分数
    /// </summary>
    public int RoomScore { get; set; }

    public int ScoreTimes { get; set; }

    /// <summary>
    /// 年-学期;yyyy-0/1
    /// </summary>
    public string YearTerm { get; set; } = null!;

    /// <summary>
    /// 是否最新学期
    /// </summary>
    public bool Old { get; set; }
}
