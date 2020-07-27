using System.Threading.Tasks;
using System.Collections.Generic;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Handlers
{
    public class GetRecognizedRevenueHandler : IQueryHandler<GetRecognizedRevenue, Money>
    {
        private readonly IQueryHandler<FindRecognitions, IEnumerable<Money>> _handler;

        public GetRecognizedRevenueHandler(IQueryHandler<FindRecognitions, IEnumerable<Money>> handler)
        {
            _handler = handler;
        }

        public async Task<Money> HandleAsync(GetRecognizedRevenue query)
        {
            var command = new FindRecognitions(query.ContractId, query.RecognizedAt);
            var recognitions = await _handler.HandleAsync(command);

            var result = Money.Dollars(0);
            foreach (var recognition in recognitions)
            {
                result.Add(recognition);
            }

            return result;
        }
    }
}
