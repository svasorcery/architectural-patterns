using System.Data;
using SvaSorcery.Patterns.Enterprise.Base.LayerSupertype.Types;
using SvaSorcery.Patterns.Enterprise.DataAccess.TableDataGateway;

namespace SvaSorcery.Patterns.Enterprise.Base.LayerSupertype
{
    public class PersonGateway : GatewayBase<Person>
    {
        public PersonGateway(DataSet dataSet) : base(dataSet, "Persons")
        {
        }

        protected override Person Map(DataRow row)
            => new Person()
            {
                Id = (int)row["Id"],
                FirstName = (string)row["FirstName"],
                LastName = (string)row["LastName"],
                Email = (string)row["Email"],
            };

        protected override DataRow Map(Person model)
        {
            var newRow = Table.NewRow();
            newRow["Id"] = model.Id;
            newRow["FirstName"] = model.FirstName;
            newRow["LastName"] = model.LastName;
            newRow["Email"] = model.Email;
            return newRow;
        }
    }
}
