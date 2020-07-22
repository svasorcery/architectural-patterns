using System;
using SvaSorcery.Patterns.Enterprise.ORM.UnitOfWork.Types;

namespace SvaSorcery.Patterns.Enterprise.ORM.UnitOfWork
{
    public static class MapperRegistryFactory
    {
        public static MapperRegistry GetMapper(Type type)
            => type == typeof(Album) ? new AlbumMapper() : null;
    }
}
