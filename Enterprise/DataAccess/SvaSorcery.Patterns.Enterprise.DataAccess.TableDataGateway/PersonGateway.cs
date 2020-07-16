using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace SvaSorcery.Patterns.Enterprise.DataAccess.TableDataGateway
{
    public class PersonGateway : TableModule
    {
        public PersonGateway(DataSet dataSet) : base(dataSet, "Persons")
        {
        }

        public IEnumerable<Person> GetAll()
            => Table.Select()
                    .Select(x => Map(x));

        public IEnumerable<Person> SearchByName(string term)
            => Table.Select($"FirstName LIKE {term}% OR LastName LIKE {term}%")
                    .Select(x => Map(x));

        public Person Find(int id)
            => Table.Select($"Id = {id}")
                    .Select(x => Map(x))
                    .First();

        public void Create(Person model)
            => Table.Rows.Add(Map(model));

        public void Update(Person model)
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

        protected Person Map(DataRow row)
            => new Person()
            {
                Id = (int)row["Id"],
                FirstName = (string)row["FirstName"],
                LastName = (string)row["LastName"],
                Email = (string)row["Email"],
            };

        protected DataRow Map(Person model)
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
