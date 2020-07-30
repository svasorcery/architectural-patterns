using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using SvaSorcery.Patterns.Enterprise.Session.DatabaseSession.Session;

namespace SvaSorcery.Patterns.Enterprise.Session.DatabaseSession.Persistence
{
    public static class MongoExtensions
    {
        public static void AddMongoRepository(this IServiceCollection services, IConfigurationSection options)
        {
            services.Configure<MongoOptions>(options);

            services.AddSingleton<IMongoRepository<QueryObject>, MongoRepository<QueryObject>>(provider =>
            {
                var options = provider.GetService<MongoOptions>();
                var client = new MongoClient(options.ConnectionString);
                var database = client.GetDatabase(options.Database);
                return new MongoRepository<QueryObject>(database, options.Collection);
            });
        }
    }
}
