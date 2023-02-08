using Shapes;
using Shapes.Exceptions;
using Shapes.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesUnitTests
{
    public class PolygonTests
    {
        [Fact]
        public void CreateIntersectionPolygonShouldThrowIntersectException()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0.0, 0.0));
            points.Add(new Point(0.0, 10.0));
            points.Add(new Point(10.0, 10.0));
            points.Add(new Point(10.0, 0.0));
            points.Add(new Point(-10.0, 25.0));

            try
            {
                Polygon polygon = new Mocks.PolygonMock(points.ToArray());
            }
            catch (IntersectSegmentsException ex) 
            {
                Assert.True(true);
                return;
            }

            Assert.Fail("");
        }

        [Fact]
        public void CreateLastPointIntersectionPolygonShouldThrowOverlapeException()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0.0, 0.0));
            points.Add(new Point(0.0, 10.0));
            points.Add(new Point(10.0, 10.0));
            points.Add(new Point(10.0, 0.0));
            points.Add(new Point(10.0, 0.0));

            try
            {
                Polygon polygon = new Mocks.PolygonMock(points.ToArray());
            }
            catch (OverlapePointsException ex)
            {
                Assert.True(true);
                return;
            }

            Assert.Fail("");
        }

        [Fact]
        public void CreateNotFirstAndLastPointIntersectPolygonShouldThrowOverlapeException()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0.0, 0.0));
            points.Add(new Point(0.0, 10.0));
            points.Add(new Point(10.0, 10.0));
            points.Add(new Point(10.0, 0.0));
            points.Add(new Point(0.0, 10.0));

            try
            {
                Polygon polygon = new Mocks.PolygonMock(points.ToArray());
            }
            catch (OverlapePointsException)
            {
                Assert.True(true);
                return;
            }

            Assert.Fail("");
        }

        [Fact]
        public void CantCloseCreatingShouldThrowIntersectException()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0.0, 0.0));
            points.Add(new Point(0.0, 10.0));
            points.Add(new Point(10.0, 10.0));
            points.Add(new Point(10.0, 0.0));
            points.Add(new Point(0.0, 20.0));
            points.Add(new Point(5.0, 20.0));

            try
            {
                Polygon polygon = new Mocks.PolygonMock(points.ToArray());
            }
            catch (IntersectSegmentsException)
            {
                Assert.True(true);
                return;
            }

            Assert.Fail("");
        }

        [Fact]
        public void CreatingWithPointOnLineShouldThrowIntersectException()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0.0, 0.0));
            points.Add(new Point(0.0, 10.0));
            points.Add(new Point(10.0, 10.0));
            points.Add(new Point(5.0, 10.0));

            try
            {
                Polygon polygon = new Mocks.PolygonMock(points.ToArray());
            }
            catch (IntersectSegmentsException)
            {
                Assert.True(true);
                return;
            }

            Assert.Fail("");
        }

        [Fact]
        public void CreatingWithOnlyTwoPointsShouldThrowInvalidException()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0.0, 0.0));
            points.Add(new Point(0.0, 10.0));

            try
            {
                Polygon polygon = new Mocks.PolygonMock(points.ToArray());
            }
            catch (InvalidGeometryException)
            {
                Assert.True(true);
                return;
            }

            Assert.Fail("");
        }

        [Fact]
        public void GetAreaForSquare()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0.0, 0.0));
            points.Add(new Point(0.0, 10.0));
            points.Add(new Point(10.0, 10.0));
            points.Add(new Point(10.0, 0.0));

            IShape polygon = new Mocks.PolygonMock(points.ToArray());

            const double expectedResult = 100.0;

            Assert.True(Math.Abs(polygon.GetArea() - expectedResult) <= Double.Epsilon);
        }

        [Fact]
        public void GetAreaForTriangle()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(1.0, 1.0));
            points.Add(new Point(15.0, -10.0));
            points.Add(new Point(-10.0, 10.0));

            IShape polygon = new Mocks.PolygonMock(points.ToArray());

            const double expectedResult = 2.5;
            Assert.True(Math.Abs(polygon.GetArea() - expectedResult) <= Double.Epsilon);
        }

        [Fact]
        public void GetAreaForNonConvexPolygon()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0.0, 0.0));
            points.Add(new Point(10.0, 0.0));
            points.Add(new Point(6.0, 6.0));
            points.Add(new Point(10.0, 10.0));
            points.Add(new Point(0.0, 10.0));
            points.Add(new Point(4.0, 4.0));

            IShape polygon = new Mocks.PolygonMock(points.ToArray());

            const double expectedResult = 60.0;
            Assert.True(Math.Abs(polygon.GetArea() - expectedResult) <= Double.Epsilon);
        }
    }
}
