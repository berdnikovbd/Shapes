using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Shapes.Exceptions;
using Point = System.Drawing.Point;

namespace Shapes.Primitives
{
    /// <summary>
    /// Represents an instance of segment on plane between two points.
    /// </summary>
    public struct Segment
    {
        /// <summary>
        /// Start point property.
        /// </summary>
        public Point StartPoint { get; init; }

        /// <summary>
        /// End point property.
        /// </summary>
        public Point EndPoint { get; init; }

        /// <summary>
        /// Initializes a new instance of <see cref="Segment"/>.
        /// </summary>
        /// <param name="start">Start point.</param>
        /// <param name="end">End point.</param>
        /// <exception cref="OverlapePointsException">First and second points are equal.</exception>
        public Segment(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;

            if (start.Equals(end))
            {
                throw new OverlapePointsException();
            }
        }

        /// <summary>
        /// Calculate length of <see cref="Segment"/>.
        /// </summary>
        /// <returns>Length between two <see cref="Point"/> of <see cref="Segment"/>.
        /// </returns>
        public double GetLength()
        {
            return Math.Sqrt((StartPoint.X - EndPoint.X) * (StartPoint.X - EndPoint.X) + (StartPoint.Y - EndPoint.Y) * (StartPoint.Y - EndPoint.Y)); 
        }
    }
}
