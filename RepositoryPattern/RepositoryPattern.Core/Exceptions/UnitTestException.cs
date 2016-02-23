using System;
using System.Runtime.Serialization;

namespace RepositoryPattern.Core.Exceptions
{
    [Serializable]
    public sealed class UnitTestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestException"/> class.
        /// </summary>
        public UnitTestException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestException"/> class.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        public UnitTestException(Exception innerException)
            : base(null, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public UnitTestException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public UnitTestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The serialization information.</param>
        /// <param name="context">The context.</param>
        protected UnitTestException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
        }
    }
}