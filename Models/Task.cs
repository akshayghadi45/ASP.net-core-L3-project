using System;
using System.Collections.Generic;

namespace CoreSkillsApp.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskDescription { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly ExpectedClosureDate { get; set; }

    public string? AssignedTo { get; set; }

    public bool CompletionStatus { get; set; }
}
