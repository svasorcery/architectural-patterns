using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Models;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Commands;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Handlers;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands
{
    public static class Extensions
    {
        public static void AddRevenueRecognitionHandlers(this IServiceCollection services)
        {
            services.AddSingleton<Gateway>(instance => new Gateway("Data Source=localhost; Initial Catalog=RevenueRecognitions; Integrated Security=True;"));
            services.AddScoped<IQueryHandler<FindContract, RevenueContract>, FindContractHandler>();
            services.AddScoped<IQueryHandler<FindRecognitions, IEnumerable<Money>>, FindRecognitionsHandler>();
            services.AddScoped<ICommandHandler<CreateRecognition>, CreateRecognitionHandler>();
            services.AddScoped<IQueryHandler<GetRecognizedRevenue, Money>, GetRecognizedRevenueHandler>();
            services.AddScoped<ICommandHandler<CalculateRevenueRecognitions>, CalculateRevenueRecognitionsHandler>();
        }
    }
}
