using System.IO;
using SvaSorcery.Patterns.Enterprise.OfflineConcurrency.Types;

namespace SvaSorcery.Patterns.Enterprise.OfflineConcurrency.Services
{
    public record FileLocker : IFileLocker
    {
        public string FilePath { get; private set; }
        public int Version { get; private set; }

        private string _fileName;

        public FileLocker(string filePath)
        {
            FilePath = filePath;
            Version = GetFileVersion(filePath);
        }

        public void Lock()
        {
            var path = Path.GetPathRoot(FilePath);
            var extension = Path.GetExtension(FilePath);
            Version++;
            var newFilePath = Path.Combine(path, $"{_fileName}_v{Version}.{extension}");
            File.Move(FilePath, newFilePath);
        }

        public void Unlock()
        {
            throw new System.NotImplementedException();
        }

        private int GetFileVersion(string filePath)
        {
            int defaultValue = 1;
            var name = Path.GetFileNameWithoutExtension(filePath);

            var index = name.LastIndexOf("_v");
            if (index < 0)
            {
                return defaultValue;
            }

            _fileName = name[..index];

            if (int.TryParse(name[index..], out int version))
            {
                return version;
            }

            return defaultValue;
        }
    }
}
