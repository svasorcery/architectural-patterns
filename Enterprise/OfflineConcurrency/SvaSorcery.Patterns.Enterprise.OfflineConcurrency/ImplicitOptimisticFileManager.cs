using System;
using System.IO;
using SvaSorcery.Patterns.Enterprise.OfflineConcurrency.Types;
using SvaSorcery.Patterns.Enterprise.OfflineConcurrency.Services;

namespace SvaSorcery.Patterns.Enterprise.OfflineConcurrency
{
    public class ImplicitOptimisticFileManager : IFileManager
    {
        public string FilePath { get; private set; }
        protected string Content { get; set; }

        private readonly IFileLocker _locker;

        public ImplicitOptimisticFileManager(string filePath)
        {
            FilePath = filePath;
            _locker = new FileLocker(filePath);
        }

        public void Read()
        {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException();

            Content = File.ReadAllText(FilePath);
        }

        public void Save()
        {
            try
            {
                _locker.Lock();
                File.AppendAllText(FilePath, Content);
            }
            catch (Exception)
            {
                throw new FileConcurrencyException();
            }
            finally
            {
                _locker.Unlock();
            }
        }
    }
}
