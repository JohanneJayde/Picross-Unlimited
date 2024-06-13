using System.Runtime.Serialization;

namespace Picross_Unlimited.Api.Services
{
    [Serializable]
    internal class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException()
        {
        }

        public ResourceNotFoundException(string? message) : base("Resource Not Found")
        {
        }

        public ResourceNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}