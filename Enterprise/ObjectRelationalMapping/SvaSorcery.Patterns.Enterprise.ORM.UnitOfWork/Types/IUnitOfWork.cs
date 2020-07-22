namespace SvaSorcery.Patterns.Enterprise.ORM.UnitOfWork.Types
{
    public interface IUnitOfWork
    {
        void RegisterNew(DomainObject obj);
        void RegisterClean(DomainObject obj);
        void RegisterDirty(DomainObject obj);
        void RegisterRemoved(DomainObject obj);
        void Commit();
        void Rollback();
    }
}
