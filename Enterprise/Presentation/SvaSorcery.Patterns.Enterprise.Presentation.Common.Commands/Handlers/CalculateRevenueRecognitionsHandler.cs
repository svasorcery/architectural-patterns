using System.Threading.Tasks;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Models;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Commands;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Handlers
{
    public class CalculateRevenueRecognitionsHandler : ICommandHandler<CalculateRevenueRecognitions>
    {
        private readonly IQueryHandler<FindContract, RevenueContract> _findContracthandler;
        private readonly ICommandHandler<CreateRecognition> _createRecognitionHandler;

        public CalculateRevenueRecognitionsHandler(
            IQueryHandler<FindContract, RevenueContract> findContracthandler,
            ICommandHandler<CreateRecognition> createRecognitionHandler)
        {
            _findContracthandler = findContracthandler;
            _createRecognitionHandler = createRecognitionHandler;
        }

        public async Task HandleAsync(CalculateRevenueRecognitions command)
        {
            var contract = await _findContracthandler.HandleAsync(new FindContract(command.ContractId));

            if (contract.Type == "W")
            {
                await _createRecognitionHandler.HandleAsync(
                    new(command.ContractId, contract.RecognizedAt, contract.TotalRevenue));
            }
            else if (contract.Type == "D")
            {
                var allocation = contract.TotalRevenue.Allocate(3);

                await _createRecognitionHandler.HandleAsync(
                    new(command.ContractId, contract.RecognizedAt, allocation[0]));

                await _createRecognitionHandler.HandleAsync(
                    new(command.ContractId, contract.RecognizedAt.AddDays(30), allocation[1]));

                await _createRecognitionHandler.HandleAsync(
                    new(command.ContractId, contract.RecognizedAt.AddDays(60), allocation[2]));
            }
            else if (contract.Type == "S")
            {
                var allocation = contract.TotalRevenue.Allocate(3);

                await _createRecognitionHandler.HandleAsync(
                    new(command.ContractId, contract.RecognizedAt, allocation[0]));

                await _createRecognitionHandler.HandleAsync(
                    new(command.ContractId, contract.RecognizedAt.AddDays(60), allocation[1]));

                await _createRecognitionHandler.HandleAsync(
                    new(command.ContractId, contract.RecognizedAt.AddDays(90), allocation[2]));
            }
        }
    }
}
