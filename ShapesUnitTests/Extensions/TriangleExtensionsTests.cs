using Shapes;
using Shapes.Extensions;
using Shapes.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesUnitTests.Extensions
{
    public class TriangleExtensionsTests
    {
        [Fact]
        public void IsTriangleRectangleTest()
        {
            var random = new Random();
            
            var firstPoint = new Point(random.NextDouble(), random.NextDouble());
            var secondPoint = new Point(random.NextDouble(), random.NextDouble());

            var firstSegment = new Segment(firstPoint, secondPoint);
            var secondSegmentLength = Math.Abs(random.NextDouble());

            var angle = Math.Atan(firstSegment.GetLength() / secondSegmentLength);
            var thirdSegmentLength = Math.Abs(firstSegment.GetLength() / Math.Sin(angle));

            var triangle = Triangle.Create(firstSegment.GetLength(), secondSegmentLength, thirdSegmentLength);

            Assert.True(triangle.IsRightAngle());
        }
    }
}
