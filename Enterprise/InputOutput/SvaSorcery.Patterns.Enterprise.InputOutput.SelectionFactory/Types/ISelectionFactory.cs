using System.Data.Common;

namespace SvaSorcery.Patterns.Enterprise.InputOutput.SelectionFactory.Types
{
    public interface ISelectionFactory<in TParams, out TResult>
        where TParams : ISearchParameters
        where TResult : DbCommand
    {
        string NewSelection(TParams parameters);
        TResult NewCommand(TParams parameters);
    }
}
