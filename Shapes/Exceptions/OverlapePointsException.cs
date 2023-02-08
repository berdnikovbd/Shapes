using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Exceptions
{
    /// <summary>
    /// Represents errors when <see cref="Point"/> of <see cref="Polygon"/> overlape other <see cref="Point"/>. 
    /// </summary>
    public class OverlapePointsException : InvalidGeometryException
    {
        /// <inheritdoc/>
        public OverlapePointsException()
        {
        }

        /// <inheritdoc/>
        public OverlapePointsException(string? message) : base(message)
        {
        }

        /// <inheritdoc/>
        public OverlapePointsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc/>
        protected OverlapePointsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
