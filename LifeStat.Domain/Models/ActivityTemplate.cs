using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;
public class ActivityTemplate
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ActivityType Type { get; set; }
}
