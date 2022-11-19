using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

public partial class StudentsInformation
{
    public string StudentId { get; set; } = null!;

    public string StudentName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string IdentityCard { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Power { get; set; }

    public string? CollegeName { get; set; }

    public string? ClassName { get; set; }

    public int Grade { get; set; }

    public int Class { get; set; }

    public string? Nature { get; set; }

    public string? Additional { get; set; }

    public string? AdminName { get; set; }
}
