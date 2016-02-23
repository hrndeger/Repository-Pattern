using System;
using System.Runtime.Serialization;

namespace RepositoryPattern.Data.Response
{
    [Serializable]
    [DataContract]
    public sealed class DeleteResponse
    {
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}