using System.Threading.Tasks;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
