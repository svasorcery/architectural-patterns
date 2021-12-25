using System.Collections;
using SvaSorcery.Patterns.Enterprise.InputOutput.UpdateFactory.Types;

namespace SvaSorcery.Patterns.Enterprise.InputOutput.UpdateFactory
{
    public class HospitalScheduleSlotUpdateFactory : IUpdateFactory<HospitalScheduleSlot>
    {
        public Hashtable NewUpdate(HospitalScheduleSlot model) => new()
        {
            { nameof(model.Date), model.Date },
            { nameof(model.TimeFrom), model.TimeFrom },
            { nameof(model.TimeTo), model.TimeTo },
            { nameof(model.SpecId), model.SpecId },
            { nameof(model.PatientId), model.PatientId },
            { nameof(model.DoctorId), model.DoctorId },
            { nameof(model.RoomId), model.RoomId }
        };
    }
}
