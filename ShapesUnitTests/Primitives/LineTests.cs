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
    public class LineTests
    {
        [Theory]
        [InlineData(1.0, 2.0)]
        public void CreateLineShoudThrowException(double x1, double y1)
        {
            var point = new Point(x1, y1);

            try
            {
                var line = new Line(point, point);
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
        public void CalcLineLength(double x1, double y1, double x2, double y2, double resultLength)
        {
            var firstPoint = new Point(x1, y1);
            var secondPoint = new Point(x2, y2);

            var line = new Line(firstPoint, secondPoint);
            var lineLength = line.GetLength();

            Assert.Equal(line.GetLength(), resultLength);
        }

    }
}
