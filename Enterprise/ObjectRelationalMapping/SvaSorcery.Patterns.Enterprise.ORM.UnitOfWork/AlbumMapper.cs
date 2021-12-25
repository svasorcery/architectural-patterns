using System;
using System.Data.SqlClient;
using SvaSorcery.Patterns.Enterprise.ORM.UnitOfWork.Types;

namespace SvaSorcery.Patterns.Enterprise.ORM.UnitOfWork
{
    public class AlbumMapper : MapperRegistry
    {
        protected override SqlConnection DbConnection
            => new("Data Source=localhost; Initial Catalog=Albums; Integrated Security=True;");

        protected override string InsertString => "INSERT INTO Albums VALUES (@id, @title)";
        protected override string SearchString => "SELECT * FROM Albums WHERE AlbumId = @id";
        protected override string UpdateString => "UPDATE Albums SET Title = @title WHERE AlbumId = @id";
        protected override string RemoveString => "DELETE FROM Albums WHERE AlbumId = @id";

        protected override DomainObject Read(int id, SqlDataReader row)
        {
            int albumId = Convert.ToInt32(row["AlbumId"]);
            string title = Convert.ToString(row["Title"]);
            return new Album(albumId, title);
        }

        protected override void AddParameters(SqlCommand query, DomainObject obj)
        {
            query.Parameters.AddWithValue("@id", ((Album)obj).Id);
            query.Parameters.AddWithValue("@title", ((Album)obj).Title);
        }

        protected override void AddParameter(SqlCommand query, int id)
        {
            query.Parameters.AddWithValue("@id", id);
        }
    }
}
