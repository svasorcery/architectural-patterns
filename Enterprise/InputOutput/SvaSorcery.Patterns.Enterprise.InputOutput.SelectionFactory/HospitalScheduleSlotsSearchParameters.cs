using System;
using SvaSorcery.Patterns.Enterprise.InputOutput.SelectionFactory.Types;

namespace SvaSorcery.Patterns.Enterprise.InputOutput.SelectionFactory
{
    public class HospitalScheduleSlotsSearchParameters : ISearchParameters
    {
        public Guid? SpecId { get; set; }
        public Guid? DoctorId { get; set; }
        public DateTime? DateFrom { get; set; }
        public TimeSpan? TimeFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public TimeSpan? TimeTo { get; set; }
    }
}
