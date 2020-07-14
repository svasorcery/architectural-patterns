using System.Collections.Generic;
using SvaSorcery.ArchitecturalPatterns.Enterprise.Cache.Common.Types;

namespace SvaSorcery.ArchitecturalPatterns.Enterprise.Cache
{
    public class CacheAccessor<T> : ICache<T> where T : IIdentifiable
    {
        protected readonly ICache<T> _cache;
        protected readonly IRepository<T> _dataAccessor;

        public CacheAccessor(ICache<T> cache, IRepository<T> dataAccessor)
        {
            _cache = cache;
            _dataAccessor = dataAccessor;
        }


        public bool Contains(int id) => _cache.Contains(id);

        public virtual IEnumerable<T> All() => _cache.All();

        public virtual T Get(int id) => _cache.Get(id);

        public virtual void Put(T item)
        {
            _dataAccessor.CreateOrUpdate(item);
            _cache.Put(item);
        }

        public virtual void Remove(int id)
        {
            _dataAccessor.RemoveById(id);
            _cache.Remove(id);
        }

        public virtual void Clear() => _cache.Clear();
    }
}
