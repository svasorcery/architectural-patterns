using System;
using System.IO;
using SvaSorcery.Patterns.Enterprise.OfflineConcurrency.Types;
using SvaSorcery.Patterns.Enterprise.OfflineConcurrency.Services;

namespace SvaSorcery.Patterns.Enterprise.OfflineConcurrency
{
    public class ImplicitPessimisticFileManager : IFileManager
    {
        public string FilePath { get; private set; }
        protected string Content { get; set; }

        private readonly IFileLocker _locker;

        public ImplicitPessimisticFileManager(string filePath)
        {
            FilePath = filePath;
            _locker = new FileLocker(filePath);
        }

        public void Read()
        {
            try
            {
                _locker.Lock();
                Content = File.ReadAllText(FilePath);
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

        public void Save()
        {
            try
            {
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
