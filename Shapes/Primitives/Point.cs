using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Primitives
{
    /// <summary>
    /// Represents an instance of point on plane.
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// X property.
        /// </summary>
        public double X;

        /// <summary>
        /// Y property.
        /// </summary>
        public double Y;

        /// <summary>
        /// Initializes a new instance of <see cref="Point"/>.
        /// </summary>
        /// <param name="x">X coordinate property.</param>
        /// <param name="y">Y coordinate property.</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns a values indication whether the values of this instance is equal to values of specified <see cref="Point"/> instance.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the <paramref name="otherPoint"/> parameters equal the values of this instance; otherwise, <see langword="false"/>.
        /// </returns>
        public bool Equals(Point otherPoint)
        {
            return X == otherPoint.X && Y == otherPoint.Y;
        }

        /// <inheritdoc cref="Equals(Point)"/> 
        public override bool Equals(object? otherPoint)
        {
            if (otherPoint is Point)
            {
                var point = (Point)otherPoint;
                return X == point.X && Y == point.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }

        public static bool operator ==(Point first, Point second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Point first, Point second)
        {
            return !first.Equals(second);
        }
    }
}