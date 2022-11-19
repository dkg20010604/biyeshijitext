using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

public partial class Disskeepinformation
{
    public string StudentId { get; set; } = null!;

    public string DiskeepType { get; set; } = null!;

    public DateTime DiskeepTime { get; set; }

    public string DiskeepText { get; set; } = null!;

    public string StudentName { get; set; } = null!;

    public string? CollegeName { get; set; }

    public int Grade { get; set; }

    public int Class { get; set; }

    public string? Nature { get; set; }

    public string? Additional { get; set; }

    public string? ClassName { get; set; }
}
