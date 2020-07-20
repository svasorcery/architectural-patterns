namespace SvaSorcery.Patterns.Enterprise.Cache.Common.Utilities
{
    public interface ICacheObservable<TKey, TValue>
    {
        void AddObserver(ICacheUpdateObserver<TKey, TValue> observer);
        void RemoveObserver(ICacheUpdateObserver<TKey, TValue> observer);
    }
}
