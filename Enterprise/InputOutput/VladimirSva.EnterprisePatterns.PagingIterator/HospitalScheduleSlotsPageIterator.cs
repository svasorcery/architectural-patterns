using System;
using System.Data.SqlClient;
using SvaSorcery.Patterns.Enterprise.InputOutput.PagingIterator.Types;
using SvaSorcery.Patterns.Enterprise.InputOutput.SelectionFactory;
using SvaSorcery.Patterns.Enterprise.InputOutput.UpdateFactory;

namespace SvaSorcery.Patterns.Enterprise.InputOutput.PagingIterator
{
    public class HospitalScheduleSlotsPageIterator : AbstractPagedIterator<HospitalScheduleSlot>
    {
        private readonly string _connectionString = "Data Source=localhost; Initial Catalog=HospitalSchedule; Integrated Security=True;";
        private readonly HospitalScheduleSlotsSqlSelectionFactory _selectionFactory;
        private readonly HospitalScheduleSlotsSearchParameters _parameters;
        private readonly int _pageSize;
        private readonly int _totalSize;

        public HospitalScheduleSlotsPageIterator(HospitalScheduleSlotsSearchParameters parameters, int pageSize = 10)
        {
            _selectionFactory = new HospitalScheduleSlotsSqlSelectionFactory();
            _parameters = parameters;
            _pageSize = pageSize;
            _totalSize = 0;
            GetPage(0);
        }

        public override int GetTotalSize() => _totalSize;

        public override int GetPageSize() => _pageSize;

        public override HospitalScheduleSlot[] GetPage(int pageNumber)
        {
            var command = _selectionFactory.NewCommand(_parameters);
            var results = new HospitalScheduleSlot[_pageSize];
            var index = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                command.Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results[++index] = new HospitalScheduleSlot()
                        {
                            Id = Guid.Parse(Convert.ToString(reader["id"])),
                            Date = Convert.ToDateTime(reader["date"]),
                            TimeFrom = TimeSpan.Parse(Convert.ToString(reader["timeFrom"])),
                            TimeTo = TimeSpan.Parse(Convert.ToString(reader["timeTo"])),
                            SpecId = Guid.Parse(Convert.ToString(reader["specId"])),
                            PatientId = Guid.Parse(Convert.ToString(reader["idpatientId"])),
                            DoctorId = Guid.Parse(Convert.ToString(reader["doctorId"])),
                            RoomId = Guid.Parse(Convert.ToString(reader["roomId"]))
                        };
                    }
                }
            }

            return results;
        }
    }
}
