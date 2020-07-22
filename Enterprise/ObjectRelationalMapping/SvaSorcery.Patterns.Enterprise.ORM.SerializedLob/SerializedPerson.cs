using System.Data;
using System.Linq;
using Newtonsoft.Json;
using SvaSorcery.Patterns.Enterprise.DataAccess.DataMapper;

namespace SvaSorcery.Patterns.Enterprise.ORM.SerializedLob
{
    public class SerializedPerson : Person
    {
        public Department Department { get; set; }


        public static new SerializedPerson Find(int id)
            => Table.Select($"Id = {id}")
                    .Select(Map)
                    .First();

        public new void Create()
        {
            Table.Rows.Add(Map(this));
            Email.Create();
        }

        public new void Update()
        {
            var row = Table.Select($"Id = {Id}").First();
            row.BeginEdit();
            row = Map(this);
            row.EndEdit();
            Email.Update();
        }

        protected static new SerializedPerson Map(DataRow row)
        {
            var person = (SerializedPerson)Person.Map(row);
            var department = (string)row["DEPARTMENT"];
            person.Department = JsonConvert.DeserializeObject<Department>(department);
            return person;
        }

        protected static DataRow Map(SerializedPerson model)
        {
            var newRow = Person.Map(model);
            newRow["DEPARTMENT"] = JsonConvert.SerializeObject(model.Department);
            return newRow;
        }
    }
}
