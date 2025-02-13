using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Notification
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual Account Account { get; set; } = null!;
}
