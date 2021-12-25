using System.Data;
using System.Linq;

namespace SvaSorcery.Patterns.Enterprise.DataAccess.DataMapper
{
    public class Email
    {
        public int Id { get; set; }
        public string Mail { get; set; }

        private static DataTable Table;

        public Email()
        {
            Table = new DataSet().Tables["EMAILS"];
        }

        public static Email GetById(int id)
            => Table.Select($"ID = {id}")
                    .Select(x => Map(x))
                    .First();

        public void Create()
            => Table.Rows.Add(Map(this));

        public void Update()
        {
            var row = Table.Select($"ID = {Id}").First();
            row.BeginEdit();
            row = Map(this);
            row.EndEdit();
        }

        protected static Email Map(DataRow row) => new()
        {
            Id = (int)row["ID"],
            Mail = (string)row["MAIL"],
        };

        protected static DataRow Map(Email model)
        {
            var newRow = Table.NewRow();
            newRow["ID"] = model.Id;
            newRow["MAIL"] = model.Mail;
            return newRow;
        }
    }
}
