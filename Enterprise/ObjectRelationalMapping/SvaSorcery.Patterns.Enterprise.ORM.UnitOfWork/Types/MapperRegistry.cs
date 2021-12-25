using System;
using System.Collections;
using System.Data.SqlClient;

namespace SvaSorcery.Patterns.Enterprise.ORM.UnitOfWork.Types
{
    public abstract class MapperRegistry
    {
        protected readonly Hashtable _loadedObjects = new();

        protected abstract SqlConnection DbConnection { get; }
        protected abstract string InsertString { get; }
        protected abstract string SearchString { get; }
        protected abstract string UpdateString { get; }
        protected abstract string RemoveString { get; }
        protected abstract DomainObject Read(int id, SqlDataReader row);
        protected abstract void AddParameters(SqlCommand query, DomainObject obj);
        protected abstract void AddParameter(SqlCommand query, int id);

        protected DomainObject Read(SqlDataReader row)
        {
            int id = row.GetInt32(0);
            if (_loadedObjects.ContainsKey(id))
            {
                return (DomainObject)_loadedObjects[id];
            }
            var result = Read(id, row);
            _loadedObjects.Add(id, result);
            return result;
        }

        public virtual void Insert(DomainObject obj)
        {
            try
            {
                var query = new SqlCommand(InsertString, DbConnection);
                AddParameters(query, obj);
                query.Connection.Open();
                query.ExecuteNonQuery();
                query.Connection.Close();
            }
            catch (SqlException)
            {
                throw new Exception($"There was an error inserting record {obj.Id}.");
            }
        }

        public virtual DomainObject Search(int id)
        {
            var result = (DomainObject)_loadedObjects[id];
            if (result != null)
            {
                return result;
            }

            var query = new SqlCommand(SearchString, DbConnection);
            query.Parameters.AddWithValue("@ id", id);
            query.Connection.Open();
            var row = query.ExecuteReader();
            row.Read();
            query.Connection.Close();
            result = Read(row);

            return result;
        }

        public virtual void Update(DomainObject obj)
        {
            try
            {
                var query = new SqlCommand(UpdateString, DbConnection);
                AddParameters(query, obj);
                query.Connection.Open();
                query.ExecuteNonQuery();
                query.Connection.Close();
            }
            catch (SqlException)
            {
                throw new Exception($"There was an error updating record {obj.Id}");
            }
        }

        public virtual void Remove(int id)
        {
            try
            {
                var query = new SqlCommand(RemoveString, DbConnection);
                AddParameter(query, id);
                query.Connection.Open();
                query.ExecuteNonQuery();
                query.Connection.Close();
            }
            catch (SqlException)
            {
                throw new Exception($"There was an error deleting record {id}");
            }
        }
    }
}