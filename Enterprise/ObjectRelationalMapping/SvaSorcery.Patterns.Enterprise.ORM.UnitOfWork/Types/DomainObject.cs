namespace SvaSorcery.Patterns.Enterprise.ORM.UnitOfWork.Types
{
    public abstract class DomainObject
    {
        abstract public int Id { get; }
        protected void MarkNew() => SimpleUnitOfWork.GetThread().RegisterNew(this);
        protected void MarkClean() => SimpleUnitOfWork.GetThread().RegisterClean(this);
        protected void MarkDirty() => SimpleUnitOfWork.GetThread().RegisterDirty(this);
        protected void MarkRemoved() => SimpleUnitOfWork.GetThread().RegisterRemoved(this);
    }
}
