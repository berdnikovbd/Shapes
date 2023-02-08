using Shapes.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Extensions
{
    /// <summary>
    /// Represents extensions for <see cref="Triangle"/>.
    /// </summary>
    public static class TriangleExtensions
    {
        /// <summary>
        /// Checks whether the triangle is rectangular.
        /// </summary>
        /// <returns><see langword="true"/> if triangle is rectangular, otherwise <see langword="false"/>.</returns>
        public static bool IsRightAngle(this Triangle triangle)
        {
            List<double> sortedLineLengths = triangle.GetLines().Select(segment => segment.GetLength()).OrderBy(x => x).ToList();

            var firstPart = Math.Truncate((sortedLineLengths[0] * sortedLineLengths[0] + sortedLineLengths[1] * sortedLineLengths[1]) * 1e12) / 1e12;
            var secondPart = Math.Truncate((sortedLineLengths[2] * sortedLineLengths[2]) * 1e12) / 1e12;

            bool result = (firstPart - secondPart) <= Double.Epsilon;

            return result;
        }
    }
}
