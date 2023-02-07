using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Shapes.Exceptions;

namespace Shapes.Primitives
{
    /// <summary>
    /// Represents an instance of line on plane between two points.
    /// </summary>
    public struct Line
    {
        /// <summary>
        /// First point property.
        /// </summary>
        public Point First { get; init; }

        /// <summary>
        /// Second point property.
        /// </summary>
        public Point Second { get; init; }

        /// <summary>
        /// Initializes a new instance of <see cref="Line"/>.
        /// </summary>
        /// <param name="first">First point.</param>
        /// <param name="second">Second point.</param>
        /// <exception cref="OverlapePointsException">First and second points are equal.</exception>
        public Line(Point first, Point second)
        {
            First = first;
            Second = second;

            if (first.Equals(second))
            {
                throw new OverlapePointsException();
            }
        }

        /// <summary>
        /// Calculate length of <see cref="Line"/>.
        /// </summary>
        /// <returns>Length between two <see cref="Point"/> of <see cref="Line"/>.
        /// </returns>
        public double GetLength()
        {
            return Math.Sqrt((First.X - Second.X) * (First.X - Second.X) + (First.Y - Second.Y) * (First.Y - Second.Y)); 
        }
    }
}
