using Shapes.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Extensions.Primitives
{
    /// <summary>
    /// Represents extensions for <see cref="Segment"/>.
    /// </summary>
    public static class SegmentExtensions
    {
        /// <summary>
        /// Find intersect between two <see cref="Segment"/>s.
        /// </summary>
        /// <param name="mainSegment">First <see cref="Segment"/>.</param>
        /// <param name="otherSegment">Second <see cref="Segment"/>.</param>
        /// <returns>
        /// <see cref="Point"/> of <see cref="Segment"/>s intersection. 
        /// <see langword="Null"/> when intersection not found or <see cref="Segment"/>s are parallel or intersect like line.
        /// </returns>
        public static Point? GetIntersectPoint(this Segment mainSegment, in Segment otherSegment)
        {
            if (mainSegment.Equals(otherSegment))
            {
                return null;
            }

            if (mainSegment.IsParallel(in otherSegment))
            {
                return null;
            }

            // Explane lines like line on plane with math defenition a*X + b*Y + c.
            double a1 = mainSegment.EndPoint.Y - mainSegment.StartPoint.Y;
            double b1 = mainSegment.StartPoint.X - mainSegment.EndPoint.X;
            double c1 = (mainSegment.StartPoint.X * mainSegment.EndPoint.Y - mainSegment.StartPoint.Y * mainSegment.EndPoint.X) * -1.0;

            double a2 = otherSegment.EndPoint.Y - otherSegment.StartPoint.Y;
            double b2 = otherSegment.StartPoint.X - otherSegment.EndPoint.X;
            double c2 = (otherSegment.StartPoint.X * otherSegment.EndPoint.Y - otherSegment.StartPoint.Y * otherSegment.EndPoint.X) * -1.0;

            // https://e-maxx.ru/algo/lines_intersection
            double denominator = a1 * b2 - a2 * b1;
            var intersection = new Point() with
            {
                X = -1 * (c1 * b2 - c2 * b1) / denominator,
                Y = -1 * (a1 * c2 - a2 * c1) / denominator
            };

            if (mainSegment.IsPointOnLine(intersection) && otherSegment.IsPointOnLine(intersection))
            {
                return intersection;
            }

            return null;
        }

        /// <summary>
        /// Check are two <see cref="Segment"/> intersect.
        /// </summary>
        /// <param name="mainSegment">First <see cref="Segment"/>.</param>
        /// <param name="otherSegment">Second <see cref="Segment"/>.</param>
        /// <returns>
        /// <see langword="true"/> if <see cref="Segment"/> are intersect, otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsIntersect(this Segment mainSegment, in Segment otherSegment)
        {
            return mainSegment.GetIntersectPoint(otherSegment).HasValue;
        }

        /// <summary>
        /// Checks whether the <see cref="Point"/> lies on the <see cref="Segment"/>.
        /// </summary>
        /// <param name="mainSegment"><see cref="Segment"/></param>
        /// <param name="point"><see cref="Point"/></param>
        /// <returns><see langword="true"/> if <see cref="Point"/> lies on the <see cref="Segment"/>, otherwise <see langword="false"/>.</returns>
        public static bool IsPointOnLine(this Segment mainSegment, Point point)
        {
            double minX = Math.Min(mainSegment.StartPoint.X, mainSegment.EndPoint.X);
            double minY = Math.Min(mainSegment.StartPoint.Y, mainSegment.EndPoint.Y);
            double maxX = Math.Max(mainSegment.StartPoint.X, mainSegment.EndPoint.X);
            double maxY = Math.Max(mainSegment.StartPoint.Y, mainSegment.EndPoint.Y);

            if (point.X >= minX && point.X <= maxX && point.Y >= minY && point.Y <= maxY)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Сhecks the parallelism of <see cref="Segment"/>s.
        /// </summary>
        /// <param name="mainSegment">First <see cref="Segment"/>.</param>
        /// <param name="otherSegment">Second <see cref="Segment"/>.</param>
        /// <see langword="true"/> if <see cref="Segment"/> are parallel, otherwise <see langword="false"/>.
        public static bool IsParallel(this Segment mainSegment, in Segment otherSegment)
        {

            // If any of lines is parallel for axis OX, other segment should be parallel for axis OX too.
            if (mainSegment.StartPoint.X == mainSegment.EndPoint.X || otherSegment.StartPoint.X == mainSegment.EndPoint.X)
            {
                if (mainSegment.StartPoint.X == mainSegment.EndPoint.X  && otherSegment.StartPoint.X == mainSegment.EndPoint.X)
                {
                    return true;
                }

                return false;
            }

            // Explane segment like line on plane with math defenition Y = k * X + b.
            double k1 = GetSlope(in mainSegment);
            double k2 = GetSlope(in otherSegment);

            // For parallel lines skopes are equal.
            return Math.Abs(k1 - k2) <= Double.Epsilon;
        }

        /// <summary>
        /// Return slope for <see cref="Segment"/>.
        /// </summary>
        /// <remarks>
        /// Slope is k for math defenition for line on plane Y = k * X + b.
        /// </remarks>
        /// <exception cref="DivideByZeroException">
        /// Throws when segment parallel for OY axis.
        /// </exception>
        private static double GetSlope(in Segment segment)
        {
            return (segment.StartPoint.Y - segment.EndPoint.Y) / (segment.StartPoint.X - segment.EndPoint.X);
        }

    }
}
