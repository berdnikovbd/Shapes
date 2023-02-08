using Shapes.Exceptions;
using Shapes.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Represents a <see cref="Triangle"/> shape model.
    /// </summary>
    public class Triangle : Polygon
    {
        /// <summary>
        /// Copy of vertexes of triangle.
        /// </summary>
        /// <returns>
        /// Copied vertexes of triangle.
        /// </returns>
        public List<Point> GetPointsCopy()
        {
            return new List<Point>(_points);
        }

        /// <inheritdoc cref="Create(Point, Point, Point)"/>
        protected Triangle(Point first, Point second, Point third)
        {
            _points = new List<Point>(3);
            this.AddPoint(first);
            this.AddPoint(second);
            this.AddPoint(third);
   
            this.Close();
        }

        /// <summary>
        /// Initilaze a new instance of <see cref="Triangle"/>, where axis OX include <see langword="firstSideLength"/> 
        /// and where <see langword="secondSideLength"/> and <see langword="thirdSideLength"/> above the OX axis.
        /// </summary>
        /// <param name="firstSideLength">Length of first side./>Line.</param>
        /// <param name="secondSideLength">Length of second side.</param>
        /// <param name="thirdSideLength">Length of third side.</param>
        /// <exception cref="InvalidGeometryException">
        /// Throws when any of two triangle's sides more then last side.
        /// </exception>
        /// <returns>
        /// A new instance of <see cref="Triangle"/>.
        /// </returns>
        public static Triangle Create(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            if (firstSideLength + secondSideLength <= thirdSideLength || secondSideLength + thirdSideLength <= firstSideLength || firstSideLength + thirdSideLength <= secondSideLength)
            {
                throw new InvalidGeometryException("Sum of any two sides of triangle should be more then third side.");
            }

            var startPoint = new Point(0.0, 0.0); 

            var firstPoint = new Point(startPoint.X, startPoint.Y);
            var secondPoint = new Point(firstSideLength, startPoint.Y);

            // * * * b * * *
            // * * / | \ * *
            // * / * | * \ *
            // *a____h____c 
            // Angle ahb is right.

            var ac = firstSideLength;
            var ab = secondSideLength;
            var bc = thirdSideLength;

            var cosBacAngle = (ac * ac + ab * ab - bc * bc ) / (2 * ab * ac) ;

            if (cosBacAngle == 0.0)
            {
                return Create(firstPoint, secondPoint, new Point(firstPoint.X, ab));
            }

            var ah = Math.Abs(ab * cosBacAngle);
            var bh = ab * Math.Sin(Math.Acos(cosBacAngle));
            var thirdPoint = new Point(ah, bh);

            return Create(firstPoint, secondPoint, thirdPoint);
        }

        /// <summary>
        /// Initilaze a new instance of <see cref="Triangle"/>.
        /// </summary>
        /// <param name="first">First <see cref="Point"/>Line.</param>
        /// <param name="second">Second <see cref="Point"/>Line.</param>
        /// <param name="third"><Third <see cref="Point"/>Line./param>
        /// <exception cref="OverlapePointsException">
        /// Throws when any of two points are equal.
        /// </exception>
        /// <exception cref="IntersectSegmentsException">
        /// Throws when one segment include all point. 
        /// </exception>
        /// <returns>
        /// A new instance of <see cref="Triangle"/>.
        /// </returns>
        public static Triangle Create(Point first, Point second, Point third)
        {
            return new Triangle(first, second, third);
        }
    }
}
