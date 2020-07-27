using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Handlers
{
    public class FindRecognitionsHandler : IQueryHandler<FindRecognitions, IEnumerable<Money>>
    {
        private readonly Gateway _gateway;

        public FindRecognitionsHandler(Gateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<IEnumerable<Money>> HandleAsync(FindRecognitions query)
        {
            var recognitions = await _gateway.FindRecognitionsForAsync(query.ContractId, query.RecognizedAt);

            return recognitions.Select(recognition =>
                Money.Dollars(Convert.ToDecimal(recognition["@amount"])));
        }
    }
}
