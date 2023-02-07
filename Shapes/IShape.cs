﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Provides of geometry shapes functionality.
    /// </summary>
    internal interface IShape
    {
        /// <summary>
        /// Calculate area of shape.
        /// </summary>
        /// <returns>Shape's area</returns>
        public float GetArea();
    }
}