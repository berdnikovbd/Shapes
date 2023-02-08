using Shapes.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Exceptions;

namespace Shapes
{
    public class Circle : Ellipse
    {
        /// <inheritdoc cref="Ellipse.Height"/>
        private new double Height { get; init; }

        /// <inheritdoc cref="Ellipse.Width"/>
        private new double Width { get; init; }

        /// <summary>
        /// The radius of <see cref="Circle"/>.
        /// </summary>
        public double Radius { get => Height / 2.0; }

        /// <summary>
        /// Initilaze a new instance of <see cref="Circle"/>. 
        /// </summary>
        /// <param name="radius">Radius of the creating <see cref="Circle"/> instance.</param>
        /// <param name="center">Center of the creating <see cref="Circle"/> instance.</param>
        /// <returns>
        /// A new instance of <see cref="Circle"/>.
        /// </returns>
        /// <exception cref="InvalidGeometryException">
        /// Throws when radius less then 0.0.
        /// </exception>
        public static Circle Create(double radius, Point center)
        {
            if (radius <= 0)
            {
                throw new InvalidGeometryException("Circle radius should be more then 0.0.");
            }

            return new Circle(radius, center);
        }

        /// <returns>
        ///  A new instance of <see cref="Circle"/> with center in (0.0, 0.0).
        /// </returns>
        /// <inheritdoc cref="Circle.Create(double, double, Point)"/>
        public static Circle Create(double radius)
        {
            return new Circle(radius, new Point(0, 0));
        }

        /// <inheritdoc cref="Create(double, Point)"/>
        protected Circle(double radius, Point center) : base(radius * 2.0, radius * 2.0, center)
        {
            if (radius <= 0) 
            {
                throw new InvalidGeometryException("Circle radius should be more then 0.0."); 
            }
        }
        
    }
}
