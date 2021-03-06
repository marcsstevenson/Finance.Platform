﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Framework.Interfaces
{
    /// <summary>
    /// Describes a weight in kilograms
    /// </summary>
    public interface IWeightKg
    {
        decimal WeightKg { get; set; }
    }
}
