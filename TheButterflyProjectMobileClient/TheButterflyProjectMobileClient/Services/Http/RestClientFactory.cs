using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Contracts;
using TheButterflyProjectMobileClient.Models.Interface;

namespace TheButterflyProjectMobileClient.Services.Http
{
    public class RestClientFactory
    {
        private readonly IHttpClientFactory _httpFactory;
        private readonly RestEndpointRegistry _registry;
        private readonly IServerEndpointProvider _provider;
        public RestClientFactory(
        IHttpClientFactory httpFactory,
        RestEndpointRegistry registry,
        IServerEndpointProvider provider)
        {
            _httpFactory = httpFactory;
            _registry = registry;
            _provider = provider;
        }

        public async Task<RestClient<T>> CreateRestClient<T>() where T : class, OfflineClientEntity
        {

            var baseUrl = _provider.ServerAdressString;

            if (string.IsNullOrWhiteSpace(baseUrl.ToString()))
                throw new InvalidOperationException("Server URL is not configured.");

            var http = _httpFactory.CreateClient();
            http.BaseAddress = new Uri(baseUrl);

            var endpoint = _registry.GetEndpoint<T>();
            return new RestClient<T>(http, endpoint);
        }

    }
}
