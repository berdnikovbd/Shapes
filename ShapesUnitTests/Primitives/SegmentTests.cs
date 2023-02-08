using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Shapes.Primitives;
using Shapes.Exceptions;

namespace ShapesUnitTests.Primitives
{
    public class SegmentTests
    {
        [Theory]
        [InlineData(1.0, 2.0)]
        public void CreateLineShouldThrowException(double x1, double y1)
        {
            var point = new Point(x1, y1);
            
            try
            {
                var segment = new Segment(point, point);
            }
            catch (OverlapePointsException)
            {
                Assert.True(true);
                return;
            }

            Assert.False(true);
        }

        [Theory]
        [InlineData(1.0, 2.0, 2.0, 1.0, 1.4142135623730951)]
        public void CalcLineLength(double x1, double y1, double x2, double y2, double excpectedResult)
        {
            var firstPoint = new Point(x1, y1);
            var secondPoint = new Point(x2, y2);

            var segment = new Segment(firstPoint, secondPoint);
            var lineLength = segment.GetLength();

            Assert.True(Math.Abs(lineLength - excpectedResult) <= Double.Epsilon);
        }

    }
}
