using System.Threading.Tasks;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types
{
    public interface ICommandHandler<in TRequest> where TRequest : ICommand
    {
        Task HandleAsync(TRequest command);
    }
}
