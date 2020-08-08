namespace SvaSorcery.Patterns.Enterprise.OfflineConcurrency.Types
{
    public interface IFileManager
    {
        string FilePath { get; }
        void Read();
        void Save();
    }
}
