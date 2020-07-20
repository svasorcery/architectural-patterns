using System.Collections.Generic;
using SvaSorcery.Patterns.Enterprise.Cache.Common.Types;

namespace SvaSorcery.Patterns.Enterprise.Cache
{
    public class PrimedCache<T> : CacheAccessor<T> where T : IIdentifiable
    {
        public PrimedCache(ICache<T> cache, IRepository<T> dataAccessor)
            : base(cache, dataAccessor)
        {
        }

        public void PrePopulate(ICollection<T> items)
        {
            foreach (var item in items)
            {
                if (!_cache.Contains(item.Id))
                    _cache.Put(item);
            }
        }
    }
}
