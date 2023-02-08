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
    /// Represents an <see cref="Ellipse"/> <see langword="shape"/> model.
    /// </summary>
    public class Ellipse : IShape
    {
        /// <summary>
        /// Center of the <see cref="Ellipse"/> instance.
        /// </summary>
        public Point Center { get; init; }

        /// <summary>
        /// Total length (diameter) of vertical axis.
        /// </summary>
        public double Height { get; init; }

        /// <summary>
        /// Total length (diameter) of horizontal axis.
        /// </summary>
        public double Width { get; init; }

        /// <summary>
        /// Initilaze a new instance of <see cref="Ellipse"/>. 
        /// </summary>
        /// <param name="height">Total length (diameter) of vertical axis.</param>
        /// <param name="width">Total length (diameter) of horizontal axis.</param>
        /// <param name="center">Center of the creating instance.</param>
        /// <returns>
        /// A new instance of <see cref="Ellipse"/>.
        /// </returns>
        /// <exception cref="InvalidGeometryException">
        /// Throws when heigth and width less then 0.0.
        /// </exception>
        public static Ellipse Create(double height, double width, Point center)
        {
           return new Ellipse(height, width, center);
        }

        /// <returns>
        ///  A new instance of <see cref="Ellipse"/> with center in (0.0, 0.0).
        /// </returns>
        /// <inheritdoc cref="Ellipse.Create(double, double, Point)"/>
        public static Ellipse Create(double height, double width)
        {
            return Ellipse.Create(height, width, new Point(0.0, 0.0));
        }

        /// <summary>
        /// Calculate area of the <see cref="Ellipse"/> instance.
        /// </summary>
        /// <returns>
        /// Area of the <see cref="Ellipse"/> instance.
        /// </returns>
        public virtual double GetArea()
        {
            return Math.PI * Height * Width / 4.0;
        }

        /// <inheritdoc cref="Ellipse.Create(double, double, Point)"/>
        protected Ellipse(double height, double width, Point center)
        {
            if (height <= 0.0 || width <= 0.0)
            {
                throw new InvalidGeometryException("Height and width should be more then 0.0");
            }

            Center = center;
            Height = height;
            Width = width;
        }

    }
}
