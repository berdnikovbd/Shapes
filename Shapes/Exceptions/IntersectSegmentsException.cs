using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Shapes.Primitives;

namespace Shapes.Exceptions
{
    /// <summary>
    /// Represents errors when <see cref="Segment"/> intersects other in <see cref="Polygon"/>. 
    /// </summary>
    public class IntersectSegmentsException : InvalidGeometryException
    {
        /// <inheritdoc/>
        public IntersectSegmentsException()
        {
        }

        /// <inheritdoc/>
        public IntersectSegmentsException(string? message) : base(message)
        {
        }

        /// <inheritdoc/>
        public IntersectSegmentsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc/>
        protected IntersectSegmentsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
