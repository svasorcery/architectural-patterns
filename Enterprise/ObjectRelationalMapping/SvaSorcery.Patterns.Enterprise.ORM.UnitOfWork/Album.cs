using SvaSorcery.Patterns.Enterprise.ORM.UnitOfWork.Types;

namespace SvaSorcery.Patterns.Enterprise.ORM.UnitOfWork
{
    public class Album : DomainObject
    {
        public override int Id { get; }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                MarkDirty();
            }
        }

        public Album(int id, string title)
        {
            Id = id;
            Title = title;
        }


        public static Album Create(int id, string name)
        {
            var album = new Album(id, name);
            album.MarkNew();
            return album;
        }

        public static void Remove(Album album) => album.MarkRemoved();
    }
}
