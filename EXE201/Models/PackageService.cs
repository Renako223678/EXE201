﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class PackageService
{
    public long Id { get; set; }

    public long PackageId { get; set; }

    public long ServiceId { get; set; }

    public double Price { get; set; }

    public bool IsActive { get; set; }

    public virtual Package Package { get; set; }

    public virtual Service Service { get; set; }
}