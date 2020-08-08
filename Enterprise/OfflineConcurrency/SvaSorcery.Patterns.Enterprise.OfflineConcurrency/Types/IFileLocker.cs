namespace SvaSorcery.Patterns.Enterprise.OfflineConcurrency.Types
{
    public interface IFileLocker
    {
        string FilePath { get; }
        int Version { get; }
        void Lock();
        void Unlock();
    }
}
