using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace SvaSorcery.Patterns.Enterprise.DataAccess.ActiveRecord
{
    public class Person : IActiveRecord, ISomeBusinessRule
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public string TableName => "Persons";
        protected static DataTable Table;

        public Person()
        {
            Table = new DataSet().Tables[TableName];
        }

        public bool IsAdult
        {
            get
            {
                var zeroDate = new DateTime(1, 1, 1);
                var diffSpan = DateTime.Now - BirthDate;
                return (zeroDate + diffSpan).Year - 1 >= 16;
            }
        }

        public bool SomeAllowed()
            => IsAdult;

        public override string ToString()
            => $"{FirstName} {LastName}, {BirthDate.ToShortDateString()} г.р.";

        public string ShortName
            => LastName +
            (string.IsNullOrEmpty(FirstName) ? "" :
            $" {FirstName.Substring(0, 1)}.");

        public static IEnumerable<Person> GetAll()
            => Table.Select()
                    .Select(x => Map(x));

        public static IEnumerable<Person> SearchByName(string term)
            => Table.Select($"FirstName LIKE {term}% OR LastName LIKE {term}%")
                    .Select(x => Map(x));

        public static Person Find(int id)
            => Table.Select($"Id = {id}")
                    .Select(x => Map(x))
                    .First();

        public void Create()
            => Table.Rows.Add(Map(this));

        public void Update()
        {
            var row = Table.Select($"Id = {Id}").First();
            row.BeginEdit();
            row = Map(this);
            row.EndEdit();
        }

        public void Delete()
            => Table.Rows.Remove(
                Table.Select($"Id = {Id}").First()
               );

        protected static Person Map(DataRow row)
            => new Person
            {
                Id = (int)row["Id"],
                FirstName = (string)row["FirstName"],
                LastName = (string)row["LastName"],
                Email = (string)row["Email"],
                BirthDate = (DateTime)row["BirthDate"]
            };

        protected static DataRow Map(Person model)
        {
            var newRow = Table.NewRow();
            newRow["Id"] = model.Id;
            newRow["FirstName"] = model.FirstName;
            newRow["LastName"] = model.LastName;
            newRow["Email"] = model.Email;
            newRow["BirthDate"] = model.BirthDate;
            return newRow;
        }
    }
}
