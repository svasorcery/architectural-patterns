using SvaSorcery.ArchitecturalPatterns.Enterprise.Cache.Common.Types;

namespace SvaSorcery.ArchitecturalPatterns.Enterprise.Cache
{
    public class DemandCache<T> : CacheAccessor<T> where T : IIdentifiable
    {
        public DemandCache(ICache<T> cache, IRepository<T> dataAccessor)
            : base (cache, dataAccessor)
        {
        }


        public override T Get(int id)
        {
            if (_cache.Contains(id))
                return _cache.Get(id);

            var item = _dataAccessor.GetById(id);
            _cache.Put(item);

            return item;
        }
    }
}
