using SvaSorcery.ArchitecturalPatterns.Enterprise.Cache.Common.Types;

namespace SvaSorcery.ArchitecturalPatterns.Enterprise.Cache
{
    public class CacheStatistics<T> : CacheAccessor<T>, ICacheStatistics where T : IIdentifiable
    {
        public int PutedCount { get; private set; } = 0;
        public int RemovedCount { get; private set; } = 0;
        public int ClearedTimes { get; private set; } = 0;

        public CacheStatistics(ICache<T> cache, IRepository<T> dataAccessor)
            : base(cache, dataAccessor)
        {
        }

        public override void Put(T value)
        {
            _cache.Put(value);
            PutedCount++;
        }

        public override void Remove(int key)
        {
            _cache.Remove(key);
            RemovedCount++;
        }

        public override void Clear()
        {
            _cache.Clear();
            ClearedTimes++;
        }
    }
}
