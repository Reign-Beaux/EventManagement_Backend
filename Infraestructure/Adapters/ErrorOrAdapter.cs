using Application.Interfaces.Adapters;
using ErrorOr;

namespace Infraestructure.Adapters
{
    public class ErrorOrAdapter : IErrorAdapter
    {
        public Error Forbidden<T>(string errorMessage, string errorName)
        {
            var errorCode = ErrorCode<T>(errorName);
            return Error.Failure(errorCode, errorMessage);
        }

        public Error NotFound<T>(string errorMessage, string errorName)
        {
            var errorCode = ErrorCode<T>(errorName);
            return Error.NotFound(errorCode, errorMessage);
        }

        public Error Unauthorized<T>(string errorMessage, string errorName)
        {
            var errorCode = ErrorCode<T>(errorName);
            return Error.Unauthorized(errorCode, errorMessage);
        }

        public Error Validation<T>(string errorMessage, string errorName)
        {
            var errorCode = ErrorCode<T>(errorName);
            return Error.Validation(errorCode, errorMessage);
        }

        private string ErrorCode<T>(string errorName)
        {
            return $"{typeof(T).Name}.{errorName}";
        }
    }
}
