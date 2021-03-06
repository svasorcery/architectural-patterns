﻿namespace SvaSorcery.Patterns.Enterprise.Cache.Common.Types
{
    public interface ICacheStatistics
    {
        int PutedCount { get; }
        int RemovedCount { get; }
        int ClearedTimes { get; }
    }
}
