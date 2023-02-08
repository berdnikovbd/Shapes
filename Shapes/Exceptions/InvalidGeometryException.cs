using System;
using System.Runtime.Serialization;

namespace Shapes.Exceptions
{
    /// <summary>
    /// Represents of errors with <see langword="shapes"/>.
    /// </summary>
    public class InvalidGeometryException : Exception
    {
        /// <inheritdoc/>
        public InvalidGeometryException()
        {
        }

        /// <inheritdoc/>
        public InvalidGeometryException(string? message) : base(message)
        {
        }

        /// <inheritdoc/>
        public InvalidGeometryException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

        /// <inheritdoc/>
        protected InvalidGeometryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
