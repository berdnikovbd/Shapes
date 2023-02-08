using Shapes.Exceptions;
using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
using Shapes.Primitives;

namespace ShapesUnitTests
{
    public class TriangleTests
    {
        [Fact]
        public void CreateTriangleShouldThrowOverlapeException()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0.0, 0.0));
            points.Add(new Point(0.0, 10.0));
            points.Add(new Point(0.0, 10.0));

            try
            {
                Triangle triangle = Triangle.Create(points[0], points[1], points[2]);
            }
            catch (OverlapePointsException)
            {
                Assert.True(true);
                return;
            }

            Assert.Fail("");
        }

        [Fact]
        public void CreateTriangleShouldThrowIntersectException()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0.0, 0.0));
            points.Add(new Point(0.0, 10.0));
            points.Add(new Point(0.0, 5.0));

            try
            {
                Triangle triangle = Triangle.Create(points[0], points[1], points[2]);
            }
            catch (IntersectSegmentsException)
            {
                Assert.True(true);
                return;
            }

            Assert.Fail("");
        }

        [Fact]
        public void CreateTriangleShouldThrowInvalidGeometryException()
        {
            try
            {
                Triangle triangle = Triangle.Create(2.0, 2.0, 5.0);
            }
            catch (InvalidGeometryException)
            {
                Assert.True(true);
                return;
            }

            Assert.Fail("");
        }

        [Fact]
        public void GetArea()
        {
            Triangle triangle = Triangle.Create(1.5, 2.0, 2.5);

            const double excpectedResult = 1.5;

            var result = triangle.GetArea();

            Assert.True(Math.Abs(triangle.GetArea() - excpectedResult) <= Double.Epsilon);
        }

        [Fact]
        public void GetAreaByPoints()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(2.3333, 1.333));
            points.Add(new Point(1.222, -3.099));
            points.Add(new Point(32.0, 123.0));

            const double excpectedResult = 1.8628613500000029;

            Triangle triangle = Triangle.Create(points[0], points[1], points[2]);

            Assert.True(triangle.GetArea() - excpectedResult <= Double.Epsilon);
        }


    }
}
