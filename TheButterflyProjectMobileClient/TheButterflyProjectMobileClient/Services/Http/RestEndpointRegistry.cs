using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheButterflyProjectMobileClient.Services.Http
{
    public class RestEndpointRegistry
    {
        private readonly Dictionary<Type, string> _endpoints = new();

        public void Register<T>(string endpoint)
        {
            _endpoints[typeof(T)] = endpoint;
        }

        public string GetEndpoint<T>()
        {
            if (_endpoints.TryGetValue(typeof(T), out var endpoint))
                return endpoint;

            throw new InvalidOperationException(
                $"No endpoint registered for {typeof(T).Name}");
        }
    }
}
