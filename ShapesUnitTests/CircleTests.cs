using Shapes.Exceptions;
using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Primitives;

namespace ShapesUnitTests
{
    public class CircleTests
    {
        [Fact]
        public void GetAreaTest()
        {
            var rnd = new Random();
            var radius = Math.Abs(rnd.NextDouble());

            IShape circle = Circle.Create(radius, new Point(rnd.NextDouble(), rnd.NextDouble()));

            var area = Math.Truncate(circle.GetArea() * 1e12) / 1e12;
            var excpectedArea = Math.Truncate(radius * radius * Math.PI * 1e12) / 1e12;

            Assert.True(Math.Abs(area - excpectedArea) <= Double.Epsilon * 100);
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(-1.0)]
        public void IncorrectCreationTest(double radius)
        {
            try
            {
                var circle = Circle.Create(radius);
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
