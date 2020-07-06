using System;

namespace ApiGateway.Clients.MvcAngular.Models
{
    public class SampleValue
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SampleEvent Created { get; set; }
    }

    public class SampleEvent
    {
        public SamplePerson By { get; set; }
        public DateTime At { get; set; }
    }

    public class SamplePerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}
