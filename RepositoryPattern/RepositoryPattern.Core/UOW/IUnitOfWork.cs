using System;

namespace RepositoryPattern.Core.UOW
{
    /// <summary>
    /// The IUnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        /// <summary>
        /// Opens the transaction.
        /// </summary>
        void OpenTransaction();

        /// <summary>
        /// Closes the transaction.
        /// </summary>
        void CloseTransaction();

    }
}