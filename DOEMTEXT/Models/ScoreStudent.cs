using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

public partial class ScoreStudent
{
    public decimal RoomScore { get; set; }

    public string YearTerm { get; set; } = null!;

    public string StudentName { get; set; } = null!;

    public string StudentId { get; set; } = null!;

    public string? Role { get; set; }
}
