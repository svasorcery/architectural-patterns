using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace SvaSorcery.Patterns.Enterprise.DataAccess.DataMapper
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmailId { get; set; }
        public Email Email { get; set; }

        protected static DataTable Table;

        public Person()
        {
            Table = new DataSet().Tables["Persons"];
        }

        public static IEnumerable<Person> GetAll()
            => Table.Select()
                    .Select(Map);

        public static IEnumerable<Person> SearchByName(string term)
            => Table.Select($"FirstName LIKE {term}% OR LastName LIKE {term}%")
                    .Select(Map);

        public static Person Find(int id)
            => Table.Select($"Id = {id}")
                    .Select(Map)
                    .First();

        public void Create()
        {
            Table.Rows.Add(Map(this));
            Email.Create();
        }

        public void Update()
        {
            var row = Table.Select($"Id = {Id}").First();
            row.BeginEdit();
            row = Map(this);
            row.EndEdit();
            Email.Update();
        }

        public void Delete()
            => Table.Rows.Remove(
                Table.Select($"Id = {Id}").First()
               );

        protected static Person Map(DataRow row)
            => new Person
            {
                Id = (int)row["Id"],
                FirstName = (string)row["FIRST_NAME"],
                LastName = (string)row["LAST_NAME"],
                EmailId = (int)row["EMAIL_ID"],
                Email = Email.GetById((int)row["EMAIL_ID"])
            };

        protected static DataRow Map(Person model)
        {
            var newRow = Table.NewRow();
            newRow["Id"] = model.Id;
            newRow["FIRST_NAME"] = model.FirstName;
            newRow["LAST_NAME"] = model.LastName;
            newRow["EMAIL_ID"] = model.EmailId;
            model.Email.Create();
            return newRow;
        }
    }
}
