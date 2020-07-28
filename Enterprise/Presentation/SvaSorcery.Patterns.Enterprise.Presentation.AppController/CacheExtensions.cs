using SvaSorcery.Patterns.Enterprise.Cache;
using SvaSorcery.Patterns.Enterprise.Cache.Common.Types;
using SvaSorcery.Patterns.Enterprise.Cache.Common.Utilities;
using SvaSorcery.Patterns.Enterprise.Presentation.AppController.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CacheExtensions
    {
        public static void AddCache(this IServiceCollection services)
        {
            services.AddScoped<CacheAccessor<Person>>();
            services.AddScoped<DemandCache<Person>>();
            services.AddScoped<CacheReplicator<Person>>();
            services.AddScoped<ICache<Person>, ReplicatedCache<Person>>();
        }
    }
}
