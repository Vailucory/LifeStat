using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;
public class Activity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ActivityTemplate Template { get; set; } = new();

    public DateTimeOffset StartTimeUtc { get; set; }

    public DateTimeOffset EndTimeUtc { get; set; }

    public DateTimeOffset StartTimeLocal { get; set; }

    public DateTimeOffset EndTimeLocal { get; set; }

}
