using System;
using System.Runtime.Serialization;
using RepositoryPattern.Core.Result;

namespace RepositoryPattern.Data.Response
{
    [Serializable]
    [DataContract]
    public class ResultBase<TResultType> : IResult<TResultType>
         where TResultType : class
    {
        [DataMember]
        public TResultType Result { get ; set; }

        [DataMember]
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has exception.
        /// </summary>
        public bool HasException
        {
            get { return Exception != null; }
        }
    }
}