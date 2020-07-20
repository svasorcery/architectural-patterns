namespace SvaSorcery.Patterns.Enterprise.Resource.ResourcePool
{
    public interface IResourcePool<T>
    {
        T GetResource();
        void PutResource(T resource);
    }
}
