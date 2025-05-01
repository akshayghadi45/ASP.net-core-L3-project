using System;
using System.Collections.Generic;

namespace CoreSkillsApp.Models;

public partial class Log
{
    public int LogId { get; set; }

    public string? Description { get; set; }

    public string? LogLevel { get; set; }

    public DateTime? LogTime { get; set; }
}
