using System;

namespace ApiGateway.Api.SampleValues.Services
{
    public partial class SampleValueService
    {
        public class SampleEvent
        {
            public SamplePerson By { get; set; }
            public DateTime At { get; set; }

            public SampleEvent()
            {

            }

            public SampleEvent(SamplePerson who, DateTime when)
            {
                By = who;
                At = when;
            }
        }
    }
}
