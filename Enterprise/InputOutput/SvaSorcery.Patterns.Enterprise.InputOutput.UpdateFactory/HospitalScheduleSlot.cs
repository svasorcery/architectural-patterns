using System;
using SvaSorcery.Patterns.Enterprise.InputOutput.UpdateFactory.Types;

namespace SvaSorcery.Patterns.Enterprise.InputOutput.UpdateFactory
{
    public class HospitalScheduleSlot : IUpdatable
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
        public Guid SpecId { get; set; }
        public Guid PatientId { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? RoomId { get; set; }

        public HospitalScheduleSlot()
        {
        }

        public HospitalScheduleSlot(DateTime date, TimeSpan timeFrom, TimeSpan timeTo,
            Guid specId, Guid patientId)
        {
            Date = date;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            SpecId = specId;
            PatientId = patientId;
        }

        public void Book(Guid? doctorId, Guid? roomId)
        {
            DoctorId = doctorId;
            RoomId = roomId;
        }
    }
}
