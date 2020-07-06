using System;

namespace ApiGateway.Clients.MvcAngular.Models
{
    public class ApiException : Exception
    {
        private readonly ApiErrorResponseResult _error;

        public ApiErrorResponseResult Error => _error;

        public ApiException(ApiErrorResponseResult error)
        {
            _error = error;
        }
    }
}
