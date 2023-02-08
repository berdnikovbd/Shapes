using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Primitives;
using Shapes.Exceptions;
using Shapes.Extensions.Primitives;

namespace ShapesUnitTests.Extensions
{
    public class SegmentExtensionsTest
    {
        [Theory]
        [InlineData(1.0, 3.0, 17.0, -2.0, -5.0, -4.0, 9.0, 3.0, 5.9230769230769234, 1.4615384615384615)]
        public void GetIntersectPointShouldReturnPoint(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, double excpectedResultX, double excpectedResultY)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);
            var p3 = new Point(x3, y3);
            var p4 = new Point(x4, y4);

            var s1 = new Segment(p1, p2);
            var s2 = new Segment(p3, p4);

            var result = s1.GetIntersectPoint(s2);
            var compareResult = Math.Abs(excpectedResultX - result.Value.X) <= Double.Epsilon * 10.0 && Math.Abs(excpectedResultY - result.Value.Y) <= Double.Epsilon * 10.0;

            Assert.True(compareResult);
        }

        [Theory]

        // Segments are equals.
        [InlineData(1.0, 145.0, 0.0, 0.0, 1.0, 145.0, 0.0, 0.0)]
        // Segments are parallel.
        [InlineData(0.0, 0.0, 1.0, 1.0, 0.0, 1.0, 1.0, 2.0)]
        // Segments intersects like line.
        [InlineData(0.0, 0.0, -18.0, 9.0, 18.0, -9.0, -24.0, 12.0)]
        // Point of segments intersections doesn't lies on segments.
        [InlineData(3.0, 1.5, -6.0, -6.0, 7.0, 8.0, -7.0, 9.0)]
        public void GetIntersectPointForShouldReturnNull(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);
            var p3 = new Point(x3, y3);
            var p4 = new Point(x4, y4);

            var s1 = new Segment(p1, p2);
            var s2 = new Segment(p3, p4);

            var result = s1.GetIntersectPoint(s2);
            Assert.Null(result);
        }

        [Theory]
        [InlineData(1.0, 3.0, 17.0, -2.0, -5.0, -4.0, 9.0, 3.0)]
        public void IsIntersectPointShouldTrue(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);
            var p3 = new Point(x3, y3);
            var p4 = new Point(x4, y4);

            var s1 = new Segment(p1, p2);
            var s2 = new Segment(p3, p4);

            Assert.True(s1.IsIntersect(s2));
        }

        [Theory]
        // Segments are equals.
        [InlineData(1.0, 145.0, 0.0, 0.0, 1.0, 145.0, 0.0, 0.0)]
        // Segments are parallel.
        [InlineData(0.0, 0.0, 1.0, 1.0, 0.0, 1.0, 1.0, 2.0)]
        // Segments intersects like line.
        [InlineData(0.0, 0.0, -18.0, 9.0, 18.0, -9.0, -24.0, 12.0)]
        // Point of segments intersections doesn't lies on segments.
        [InlineData(3.0, 1.5, -6.0, -6.0, 7.0, 8.0, -7.0, 9.0)]
        public void IsIntersectPointShouldFalse(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);
            var p3 = new Point(x3, y3);
            var p4 = new Point(x4, y4);

            var s1 = new Segment(p1, p2);
            var s2 = new Segment(p3, p4);

            Assert.False(s1.IsIntersect(s2));
        }

        [Theory]
        // Segments are equals.
        [InlineData(1.0, 145.0, 0.0, 0.0, 1.0, 145.0, 0.0, 0.0)]
        // Segments intersects like line.
        [InlineData(0.0, 0.0, -18.0, 9.0, 18.0, -9.0, -24.0, 12.0)]
        // Segments are parallel.
        [InlineData(0.0, 0.0, 1.0, 1.0, 0.0, 1.0, 1.0, 2.0)]
        public void IsParallelShouldReturnTrue(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);
            var p3 = new Point(x3, y3);
            var p4 = new Point(x4, y4);

            var s1 = new Segment(p1, p2);
            var s2 = new Segment(p3, p4);

            Assert.True(s1.IsParallel(s2));
        }

        [Theory]
        // Point of segments intersections doesn't lies on segments.
        [InlineData(3.0, 1.5, -6.0, -6.0, 7.0, 8.0, -7.0, 9.0)]
        // Segments intersects.
        [InlineData(1.0, 3.0, 17.0, -2.0, -5.0, -4.0, 9.0, 3.0)]
        public void IsParallelShouldReturnFalse(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);
            var p3 = new Point(x3, y3);
            var p4 = new Point(x4, y4);

            var s1 = new Segment(p1, p2);
            var s2 = new Segment(p3, p4);

            Assert.False(s1.IsParallel(s2));
        }
    }
}
