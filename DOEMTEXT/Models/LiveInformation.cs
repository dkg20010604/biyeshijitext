using System;
using System.Collections.Generic;

namespace DOEMTEXT.Models;

public partial class LiveInformation
{
    public string StudentId { get; set; } = null!;

    public string StudentName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string IdentityCard { get; set; } = null!;

    public int BuildId { get; set; }

    public string? ManageId { get; set; }

    public int RoomNumber { get; set; }

    public decimal? ElectricityFees { get; set; }

    public int? BedId { get; set; }

    public string? Role { get; set; }
}
