using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
using Shapes.Exceptions;
using Shapes.Primitives;

namespace ShapesUnitTests
{
    public class EllipseTests
    {
        [Theory]
        [InlineData(3.0, 1.0, 0.0, 0.0, 2.3561944901923448)]
        [InlineData(2468.8642, 486.864  , 333.0, 777.0, 944049.4562386683)]
        public void GetAreaTest(double height, double width, double centerX, double centerY, double excpectedResult)
        {
            IShape elipse = Ellipse.Create(height, width, new Point(centerX, centerY));

            var area = elipse.GetArea();

            Assert.True(Math.Abs(area - excpectedResult) <= Double.Epsilon);
        }

        [Theory]
        [InlineData(0.0, 1.0)]
        [InlineData(1.0, 0.0)]
        [InlineData(-1.0, 1.0)]
        [InlineData(1.0, -1.0)]
        public void IncorrectCreationTest(double height, double width)
        {
            try
            {
                var elipse = Ellipse.Create(height, width);
            }
            catch (InvalidGeometryException)
            {
                Assert.True(true);
                return;
            }

            Assert.Fail("");
        }
    }
}
