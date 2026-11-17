using System;
using System.Collections.Generic;

namespace DVLD.Shared.Models;

public partial class LoginAttempt
{
    public long LoginAttemptId { get; set; }

    public int? UserId { get; set; }

    public string AttemptedUserName { get; set; } = null!;

    public bool Succeeded { get; set; }

    public DateTime AttemptedAtUtc { get; set; }

    public string? ClientIpAddress { get; set; }
}
