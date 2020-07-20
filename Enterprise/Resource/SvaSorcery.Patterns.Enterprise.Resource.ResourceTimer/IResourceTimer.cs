using System.Timers;

namespace SvaSorcery.Patterns.Enterprise.Resource.ResourceTimer
{
    public interface IResourceTimer
    {
        void Start();
        void Stop();
        void Reset();

        void AddListener(ElapsedEventHandler handler);
        void RemoveListener(ElapsedEventHandler handler);
    }
}
