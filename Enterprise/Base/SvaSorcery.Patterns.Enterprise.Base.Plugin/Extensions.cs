using SvaSorcery.Patterns.Enterprise.Base.Plugin;
using SvaSorcery.Patterns.Enterprise.Base.SpecialCase;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Extensions
    {
        public static void AddPersonPlugin(this IServiceCollection services)
            => services.AddScoped<IPersonExtensions, HttpContextUserPersonPlugin>();
    }
}
