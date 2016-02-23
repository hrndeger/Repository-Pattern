using System;

namespace RepositoryPattern.Models
{
    [Serializable]
    public sealed class JsonResultModel
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}