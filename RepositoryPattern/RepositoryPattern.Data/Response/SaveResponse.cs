using System;
using System.Runtime.Serialization;

namespace RepositoryPattern.Data.Response
{
    [Serializable]
    [DataContract]
    public sealed class SaveResponse
    {
        [DataMember]
        public bool IsSuccess { get; set; }
    }
}