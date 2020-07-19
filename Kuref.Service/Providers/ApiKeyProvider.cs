using System;
using System.Threading.Tasks;
using System.Linq;
using Kuref.Service.Data;
using AspNetCore.Authentication.ApiKey;

namespace Kuref.Service.Providers
{
    public class ApiKeyProvider: IApiKeyProvider
    {
        private readonly KurefContext context;
        public ApiKeyProvider(KurefContext context)
        {
            this.context = context;
        }

        public Task<IApiKey> ProvideAsync(string key)
        {
            IApiKey apiKey = context.ApiKeys.FirstOrDefault(a => a.Key == key && a.Enabled);
            return Task.FromResult(apiKey);
        }
    }
}
