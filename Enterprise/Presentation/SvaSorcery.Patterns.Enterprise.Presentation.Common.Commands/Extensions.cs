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
            => services
            .AddSingleton<Gateway>(instance => new Gateway("Data Source=localhost; Initial Catalog=RevenueRecognitions; Integrated Security=True;"))
            .AddScoped<IQueryHandler<FindContract, RevenueContract>, FindContractHandler>()
            .AddScoped<IQueryHandler<FindRecognitions, IEnumerable<Money>>, FindRecognitionsHandler>()
            .AddScoped<ICommandHandler<CreateRecognition>, CreateRecognitionHandler>()
            .AddScoped<IQueryHandler<GetRecognizedRevenue, Money>, GetRecognizedRevenueHandler>()
            .AddScoped<ICommandHandler<CalculateRevenueRecognitions>, CalculateRevenueRecognitionsHandler>();
    }
}
