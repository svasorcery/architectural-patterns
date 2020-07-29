using System.Threading.Tasks;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Commands;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Handlers
{
    public class CreateRecognitionHandler : ICommandHandler<CreateRecognition>
    {
        private readonly Gateway _gateway;

        public CreateRecognitionHandler(Gateway gateway)
        {
            _gateway = gateway;
        }

        public Task HandleAsync(CreateRecognition command)
            => _gateway.InsertRecognitionAsync(command.ContractId, command.Money, command.RecognizedAt);
    }
}
