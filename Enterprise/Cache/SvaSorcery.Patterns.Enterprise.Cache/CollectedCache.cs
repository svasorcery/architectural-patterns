﻿using System;
using System.Timers;
using SvaSorcery.Patterns.Enterprise.Cache.Common.Types;
using SvaSorcery.Patterns.Enterprise.Cache.Common.Utilities;

namespace SvaSorcery.Patterns.Enterprise.Cache
{
    public class CollectedCache<T> : CacheAccessor<T> where T : IIdentifiable
    {
        private readonly EventTimer _collectTimer;

        public CollectedCache(ICache<T> cache, IRepository<T> dataAccessor, TimeSpan collectTime)
            : base(cache, dataAccessor)
        {
            _collectTimer = new EventTimer(collectTime);
            _collectTimer.AddListener(OnTimedEvent);
        }


        public void Collect() => _cache.Clear();

        private void OnTimedEvent(Object source, ElapsedEventArgs e) => Collect();
    }
}
