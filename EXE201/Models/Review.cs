﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Review
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public long PackageId { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; }

    public DateOnly CreateDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Account Account { get; set; }

    public virtual Package Package { get; set; }
}