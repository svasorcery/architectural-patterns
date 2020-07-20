using System;

namespace SvaSorcery.Patterns.Enterprise.Resource.Retryer
{
    public interface IRetryer
    {
        void Do(Action action, TimeSpan retryInterval, int maxAttemptCount);
        T Do<T>(Func<T> action, TimeSpan retryInterval, int maxAttemptCount);
    }
}
