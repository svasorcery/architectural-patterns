using System.Collections.Generic;
using SvaSorcery.Patterns.Enterprise.Cache.Common.Types;
using SvaSorcery.Patterns.Enterprise.Cache.Common.Utilities;

namespace SvaSorcery.Patterns.Enterprise.Cache
{
    public class ReplicatedCache<T> : CacheAccessor<T>, ICacheObservable<int, T> where T : IIdentifiable
    {
        private readonly List<ICacheUpdateObserver<int, T>> _observers;

        public ReplicatedCache(ICache<T> cache, IRepository<T> dataAccessor)
            : base(cache, dataAccessor)
        {
            _observers = new List<ICacheUpdateObserver<int, T>>();
        }

        public void AddObserver(ICacheUpdateObserver<int, T> observer)
            => _observers.Add(observer);

        public void RemoveObserver(ICacheUpdateObserver<int, T> observer)
            => _observers.Remove(observer);

        public override void Put(T value)
        {
            _cache.Put(value);
            _observers.ForEach(observer => observer.EntryAdded(value.Id, value));
        }

        public override void Remove(int key)
        {
            _cache.Remove(key);
            _observers.ForEach(observer => observer.EntryRemoved(key));
        }

        public override void Clear()
        {
            _cache.Clear();
            _observers.ForEach(observer => observer.EntriesCleared());
        }
    }
}
