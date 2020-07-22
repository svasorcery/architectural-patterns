using System;

namespace SvaSorcery.Patterns.Enterprise.ORM.EmbeddedValue
{
    public class HospitalScheduleSlot
    {
        public Guid Id { get; }
        public DateTime Date { get; }
        public TimeRange TimeRange { get; }
        public Guid SpecId { get; }
        public Guid PatientId { get; }
        public Guid? DoctorId { get; private set; }
        public Guid? RoomId { get; private set; }

        public HospitalScheduleSlot(DateTime date, TimeRange timeRange, Guid specId, Guid patientId)
        {
            Id = Guid.NewGuid();
            Date = date;
            TimeRange = timeRange;
            SpecId = specId;
            PatientId = patientId;
        }
    }
}
