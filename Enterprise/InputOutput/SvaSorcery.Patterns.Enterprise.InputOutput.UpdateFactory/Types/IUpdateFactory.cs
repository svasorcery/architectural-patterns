using System.Collections;

namespace SvaSorcery.Patterns.Enterprise.InputOutput.UpdateFactory.Types
{
    public interface IUpdateFactory<T> where T : IUpdatable
    {
        Hashtable NewUpdate(T model);
    }
}
