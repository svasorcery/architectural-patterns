using SvaSorcery.Patterns.Enterprise.Cache.Common.Types;

namespace SvaSorcery.Patterns.Enterprise.Cache.Common.Utilities
{
    public class CacheReplicator<T> : ICacheUpdateObserver<int, T> where T : IIdentifiable
    {
        private readonly ICache<T> _cache;

        public CacheReplicator(ICache<T> cache)
        {
            _cache = cache;
        }

        public void EntryAdded(int key, T value) => _cache.Put(value);

        public void EntryRemoved(int key) => _cache.Remove(key);

        public void EntriesCleared() => _cache.Clear();
    }
}
