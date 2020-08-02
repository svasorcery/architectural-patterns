using System.Data;
using System.Linq;
using System.Collections.Generic;
using SvaSorcery.Patterns.Enterprise.DataAccess.TableDataGateway;

namespace SvaSorcery.Patterns.Enterprise.Base.LayerSupertype.Types
{
    public abstract class GatewayBase<T> : TableModule where T : IIdentifiable
    {
        public GatewayBase(DataSet dataSet, string tableName) : base(dataSet, tableName)
        {
        }

        public IEnumerable<T> GetAll()
            => Table.Select()
                    .Select(x => Map(x));

        public IEnumerable<T> SearchByName(string sqlQuery)
            => Table.Select(sqlQuery)
                    .Select(x => Map(x));

        public T Find(int id)
            => Table.Select($"Id = {id}")
                    .Select(x => Map(x))
                    .First();

        public void Create(T model)
            => Table.Rows.Add(Map(model));

        public void Update(T model)
        {
            var row = Table.Select($"Id = {model.Id}").First();
            row.BeginEdit();
            row = Map(model);
            row.EndEdit();
        }

        public void Delete(int id)
            => Table.Rows.Remove(
                Table.Select($"Id = {id}").First()
               );

        protected abstract T Map(DataRow row);

        protected abstract DataRow Map(T model);
    }
}
