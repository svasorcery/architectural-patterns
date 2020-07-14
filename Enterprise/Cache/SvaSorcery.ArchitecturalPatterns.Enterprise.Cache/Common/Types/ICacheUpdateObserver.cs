namespace SvaSorcery.ArchitecturalPatterns.Enterprise.Cache.Common.Utilities
{
    public interface ICacheUpdateObserver<TKey, TValue>
    {
        void EntryAdded(TKey key, TValue value);
        void EntryRemoved(TKey key);
        void EntriesCleared();
    }
}
