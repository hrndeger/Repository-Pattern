using System;

namespace RepositoryPattern.Core.Result
{
    /// <summary>
    /// IResult interface
    /// </summary>
    /// <typeparam name="TResultType">The type of the result type.</typeparam>
    public interface IResult<TResultType>
        where TResultType : class
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        TResultType Result { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        Exception Exception { get; set; }
    }
}