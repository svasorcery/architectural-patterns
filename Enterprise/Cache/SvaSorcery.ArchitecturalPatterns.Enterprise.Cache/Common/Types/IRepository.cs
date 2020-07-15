using System.Collections.Generic;

namespace SvaSorcery.ArchitecturalPatterns.Enterprise.Cache.Common.Types
{
    public interface IRepository<T> where T : IIdentifiable
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void CreateOrUpdate(T item);
        void RemoveById(int id);
    }
}
