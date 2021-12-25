using System.Data;

namespace SvaSorcery.Patterns.Enterprise.DataAccess.TableDataGateway
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
