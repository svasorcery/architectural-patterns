using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiGateway.Clients.MvcAngular.Services
{
    using ApiGateway.Clients.MvcAngular.Models;

    public class SampleValuesApiClient : AbstractServiceClient
    {
        private readonly SampleValuesApiClientOptions _options;

        protected override string BaseUrl => "http://localhost:50280"; //_options.BaseUrl;
        protected override bool CamelCaseSerialization => true;

        public SampleValuesApiClient(IOptions<SampleValuesApiClientOptions> optionsAccessor, ILogger<SampleValuesApiClient> logger)
            : base(logger)
        {
            _options = optionsAccessor.Value;
        }


        public Task<IEnumerable<SampleValue>> GetAllAsync() => Get<IEnumerable<SampleValue>>("api/values");

        public Task<SampleValue> GetByIdAsync(int id) => Get<SampleValue>($"api/values/{id}");

        public Task<SampleValue> CreateAsync(SampleValue p) => Post<SampleValue, SampleValue>("api/values", p);

        public Task<SampleValue> UpdateAsync(int id, SampleValue p) => Put<SampleValue, SampleValue>($"api/values/{id}", p);

        public Task DeleteAsync(int id) => Delete($"api/values/{id}");
    }
}
