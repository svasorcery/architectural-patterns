using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SvaSorcery.Patterns.Enterprise.InputOutput.SelectionFactory.Types;

namespace SvaSorcery.Patterns.Enterprise.InputOutput.SelectionFactory
{
    public class HospitalScheduleSlotsSqlSelectionFactory : ISelectionFactory<HospitalScheduleSlotsSearchParameters, SqlCommand>
    {
        public string NewSelection(HospitalScheduleSlotsSearchParameters parameters)
        {
            var sb = new StringBuilder();

            if (parameters.SpecId != null)
                sb.Append($"SpecId = {parameters.SpecId} AND ");

            if (parameters.DoctorId != null)
                sb.Append($"DoctorId = {parameters.DoctorId} AND ");

            if (parameters.DateFrom != null)
                sb.Append($"Date >= {parameters.DateFrom} AND ");

            if (parameters.TimeFrom != null)
                sb.Append($"Time >= {parameters.TimeFrom} AND ");

            if (parameters.DateTo != null)
                sb.Append($"Date <= {parameters.DateTo} AND ");

            if (parameters.TimeTo != null)
                sb.Append($"Time <= {parameters.TimeTo} AND ");

            var result = sb.Remove(sb.Length, -5)?.ToString();

            return result;
        }

        public SqlCommand NewCommand(HospitalScheduleSlotsSearchParameters parameters)
        {
            var selectionBuider = new StringBuilder("SELECT * FROM dbo.Slots WHERE ");
            var paramCollection = new List<SqlParameter>();

            if (parameters.SpecId != null)
            {
                selectionBuider.Append("SpecId = @specId AND ");
                paramCollection.Add(new SqlParameter("@specId", SqlDbType.UniqueIdentifier) { Value = parameters.SpecId });
            }

            if (parameters.DoctorId != null)
            {
                selectionBuider.Append("DoctorId = @doctorId AND ");
                paramCollection.Add(new SqlParameter("@doctorId", SqlDbType.UniqueIdentifier) { Value = parameters.DoctorId });
            }

            if (parameters.DateFrom != null)
            {
                selectionBuider.Append("Date >= @dateFrom AND ");
                paramCollection.Add(new SqlParameter("@dateFrom", SqlDbType.Date) { Value = parameters.DateFrom });
            }

            if (parameters.TimeFrom != null)
            {
                selectionBuider.Append("Time >= @timeFrom AND ");
                paramCollection.Add(new SqlParameter("@timeFrom", SqlDbType.Time) { Value = parameters.TimeFrom });
            }

            if (parameters.DateTo != null)
            {
                selectionBuider.Append("Date <= @dateTo AND ");
                paramCollection.Add(new SqlParameter("@dateTo", SqlDbType.Date) { Value = parameters.DateTo });
            }

            if (parameters.TimeTo != null)
            {
                selectionBuider.Append("Time <= @timeTo AND ");
                paramCollection.Add(new SqlParameter("@timeTo", SqlDbType.Time) { Value = parameters.TimeTo });
            }

            var sqlExpression = selectionBuider.Remove(selectionBuider.Length, -5)?.ToString();

            var command = new SqlCommand(sqlExpression);
            command.Parameters.AddRange(paramCollection.ToArray());

            return command;
        }
    }
}
