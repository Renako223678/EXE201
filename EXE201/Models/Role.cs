using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Role
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
