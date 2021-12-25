using System;
using System.Threading;
using System.Collections;
using System.Transactions;
using SvaSorcery.Patterns.Enterprise.ORM.UnitOfWork.Types;

namespace SvaSorcery.Patterns.Enterprise.ORM.UnitOfWork
{
    public class SimpleUnitOfWork : IUnitOfWork
    {
        private readonly ArrayList _newObjects = new();
        private readonly ArrayList _dirtyObjects = new();
        private readonly ArrayList _removedObjects = new();
        private static readonly LocalDataStoreSlot _thread = Thread.AllocateNamedDataSlot("thread");

        public void RegisterNew(DomainObject obj)
        {
            if (obj.Id == 0)
                throw new ArgumentException("Id is null");

            if (_dirtyObjects.Contains(obj))
                throw new ArgumentException("Can't register a dirty object as new");

            if (_removedObjects.Contains(obj))
                throw new ArgumentException("Can't register a removed object as new");

            if (_newObjects.Contains(obj))
                throw new ArgumentException("The object has already been registered");

            _newObjects.Add(obj);
        }

        public void RegisterClean(DomainObject obj)
        {
            if (obj.Id == 0)
                throw new ArgumentException("Id is null");
        }

        public void RegisterDirty(DomainObject obj)
        {
            if (obj.Id == 0)
                throw new ArgumentException("Id is null");

            if (_removedObjects.Contains(obj))
                throw new ArgumentException("Can't register a removed object as dirty");

            if (!_dirtyObjects.Contains(obj) && !_newObjects.Contains(obj))
            {
                _dirtyObjects.Add(obj);
            }
        }

        public void RegisterRemoved(DomainObject obj)
        {
            if (obj.Id == 0)
            {
                throw new ArgumentException("Id is null");
            }
            if (_newObjects.Contains(obj))
            {
                _newObjects.Remove(obj);
            }
            if (_dirtyObjects.Contains(obj))
            {
                _dirtyObjects.Remove(obj);
            }
            if (!_removedObjects.Contains(obj))
            {
                _removedObjects.Remove(obj);
            }
            _removedObjects.Add(obj);
        }

        public void Commit()
        {
            using var transaction = new TransactionScope();
            InsertNew();
            UpdateDirty();
            DeleteRemoved();
            transaction.Complete();
        }

        public void Rollback()
        {
        }

        private void InsertNew()
        {
            foreach (DomainObject obj in _newObjects)
            {
                MapperRegistryFactory.GetMapper(obj.GetType()).Insert(obj);
            }
        }

        private void UpdateDirty()
        {
            foreach (DomainObject obj in _dirtyObjects)
            {
                MapperRegistryFactory.GetMapper(obj.GetType()).Update(obj);
            }
        }

        private void DeleteRemoved()
        {
            foreach (DomainObject obj in _removedObjects)
            {
                MapperRegistryFactory.GetMapper(obj.GetType()).Remove(obj.Id);
            }
        }

        public static void NewThread() => SetThread(new SimpleUnitOfWork());
        public static void SetThread(SimpleUnitOfWork unitOfWork) => Thread.SetData(_thread, unitOfWork);
        public static SimpleUnitOfWork GetThread() => (SimpleUnitOfWork)Thread.GetData(_thread);
    }
}