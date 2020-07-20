using System.Collections.Generic;

namespace SvaSorcery.Patterns.Enterprise.Cache.Common.Types
{
    public interface ICache<T> where T : IIdentifiable
    {
        bool Contains(int id);
        IEnumerable<T> All();
        T Get(int id);
        void Put(T item);
        void Remove(int id);
        void Clear();
    }
}
