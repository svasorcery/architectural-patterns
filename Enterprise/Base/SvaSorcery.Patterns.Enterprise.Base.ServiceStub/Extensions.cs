using Microsoft.Extensions.DependencyInjection;

namespace SvaSorcery.Patterns.Enterprise.Base.ServiceStub
{
    public static class Extensions
    {
        public static void AddCalculatorService(this IServiceCollection services)
        {
            services.AddScoped<ICalculatorService, CalculatorServiceStub>();
        }
    }
}
