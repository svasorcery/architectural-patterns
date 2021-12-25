using System.Data;

namespace SvaSorcery.Patterns.Enterprise.Domain.TableModule
{
    public class TableModule
    {
        protected readonly DataTable Table;

        protected TableModule(DataSet dataSet, string tableName)
        {
            Table = dataSet.Tables[tableName];
        }
    }
}
