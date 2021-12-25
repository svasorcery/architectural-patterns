using System.Collections.Generic;

namespace SvaSorcery.Patterns.Enterprise.ORM.IdentityMap.Types
{
    public class GenericIdentityMap
    {
        protected static readonly GenericIdentityMap _instance = new();
        protected readonly Dictionary<int, object> _pool = new();

        public static T Get<T>(int id) where T : DomainObject
            => (T)_instance._pool[id];

        public static void Add<T>(T item) where T : DomainObject
            => _instance._pool.Add(item.Id, item);

        public static void Remove(int id)
            => _instance._pool.Remove(id);
    }
}
