using Shapes.Exceptions;
using Shapes.Extensions.Primitives;
using Shapes.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// A <see langword="shape"/> where the <see cref="Segment"/> do not intersect.
    /// </summary>
    /// <remarks>
    /// Can be convex and non convex.
    /// </remarks>
    public abstract class Polygon : IShape
    {
        /// <summary>
        /// <see cref="Point"/>s container.
        /// </summary>
        protected List<Point> _points = new List<Point>();

        /// <summary>
        /// Is <see cref="Polygon"/> open for <see cref="Polygon.AddPoint(Point)"/> or <see cref="Polygon.TryAddPoint(Point)"/>.
        /// </summary>
        protected bool IsAbleForAddingPoint { get; set; } = true;

        /// <summary>
        /// Generete <see cref="Segment"/> from <see cref="Polygon"/>'s points.
        /// </summary>
        /// <returns>List of <see cref="Polygon"/> lines.</returns>
        public virtual List<Segment> GetLines()
        {
            if (_points.Count == 0)
            {
                return new List<Segment>();
            }

            var lines = new List<Segment>(_points.Count - 1);

            for (var i = 1; i < _points.Count; i++)
            {
                lines.Add(new Segment(_points[i - 1], _points[i]));
            }

            if (!IsAbleForAddingPoint)
            {
                lines.Add(new Segment(_points.Last(), _points.First()));
            }

            return lines;
        }

        /// <summary>
        /// Calculate area of <see cref="Polygon"/>.
        /// </summary>
        /// <returns><see cref="Polygon"/>'s area.</returns>
        /// <exception cref="InvalidGeometryException">
        /// Throws when <see cref="Polygon"/> is invalid.
        /// </exception>
        public virtual double GetArea()
        {
            if (IsAbleForAddingPoint)
            {
                throw new InvalidGeometryException("Polygon is not closed.");
            }

            // Shoelace formula.
            // https://en.wikipedia.org/wiki/Shoelace_formula

            double area = 0.0;
            int iY1 = 0;
            int iY2 = 0;

            for (var iX = 0; iX < _points.Count; iX++)
            {
                iY1 = iX - 1;
                iY1 = iY1 < 0 ? _points.Count - 1 : iY1;
                
                iY2 = iX + 1;
                iY2 = iY2 >= _points.Count ? 0 : iY2;

                area += _points[iX].X * (_points[iY2].Y - _points[iY1].Y);
            }


            return Math.Abs(area) / 2.0;
        }

        /// <summary>
        /// Add <see cref="Point"/> in <see cref="Polygon"/> instance. 
        /// </summary>
        /// <param name="point">Adding <see cref="Point"/>.</param>
        /// <exception cref="InvalidGeometryException">
        /// Throws when trying add <see cref="Point"/> in closed <see cref="Polygon"/> or trying close <see cref="Polygon"/> with 2 or less <see cref="Point"/>s.
        /// </exception>
        /// <exception cref="OverlapePointsException">
        /// Throws when trying add <see cref="Point"/> which not equals first <see cref="Point"/> and already exist.
        /// </exception>
        /// <exception cref="IntersectSegmentsException">
        /// Throws when trying add <see cref="Point"/> which create <see cref="Segment"/> intersect one or more segments in <see cref="Polygon"/>.
        /// </exception>
        /// <remarks>
        /// If adding <paramref name="point"/> equals first <see cref="Point"/> of instnace for adding new <see cref="Point"/>s, then close <see cref="Polygon"/> instnace and don't dublicate <see cref="Point"/>.
        /// </remarks>
        protected virtual void AddPoint(Point point) 
        {
            if (!IsAbleForAddingPoint)
            {
                throw new InvalidGeometryException();
            }

            if (_points.Count <= 1)
            {
                _points.Add(point);
                return;
            }

            if (_points.Skip(1).Any(p => p.Equals(point)))
            {
                throw new OverlapePointsException();
            }

            var creatingLine = new Segment(_points.Last(), point);
            var checkingLinesForOverlape = new List<Segment>(_points.Count - 1);

            for (var i = 1; i < _points.Count - 1; i++)
            {
                checkingLinesForOverlape.Add(new Segment(_points[i - 1], _points[i]));
            }

            if (_points.First() == point)
            {
                checkingLinesForOverlape = checkingLinesForOverlape.Skip(1).ToList();
            }

            if (checkingLinesForOverlape.Count == 0)
            {
                var firstLine = new Segment(_points.First(), _points.Skip(1).First());

                if (firstLine.IsParallel(creatingLine))
                {
                    throw new IntersectSegmentsException();
                }
            }

            if (checkingLinesForOverlape.Any(l => l.IsIntersect(creatingLine)))
            {
                throw new IntersectSegmentsException();
            }
            
            IsAbleForAddingPoint = _points.First() != point;

            if (IsAbleForAddingPoint)
            {
                _points.Add(point);
            }
        }

        /// <summary>
        /// Try to add <see cref="Point"/> in <see cref="Polygon"/> instance.
        /// </summary>
        /// <param name="point">Adding <see cref="Point"/> instance.</param>
        /// <returns>
        /// <see langword="true"/> if <see cref="Point"/> added succsesful, else returns <seealso langword="false"/>.
        /// </returns>
        /// <remarks>
        /// If adding <paramref name="point"/> equals first <see cref="Point"/> of instnace for adding new <see cref="Point"/>s,
        /// then close <see cref="Polygon"/> instnace and don't dublicate <see cref="Point"/> and return <see langword="true"/>.
        /// </remarks>
        protected virtual bool TryAddPoint(Point point)
        {
            try
            {
                AddPoint(point);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Close the <see cref="Polygon"/> instance for adding <see cref="Point"/>s.
        /// </summary>
        /// <exception cref="IntersectSegmentsException">
        /// Throws when <see cref="Segment"/> of last and first <see cref="Point"/>s intersects one or more lines in <see cref="Polygon"/> instance.
        /// </exception>
        protected void Close()
        {
            if (!IsAbleForAddingPoint)
            {
                return;
            }

            AddPoint(_points.First());

            if (_points.Count <= 2)
            {
                throw new InvalidGeometryException();
            }

            IsAbleForAddingPoint = false;
        }

    }
}
