namespace ApiGateway.Api.SampleValues.Services
{
    public partial class SampleValueService
    {
        public class SampleValue
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public SampleEvent Created { get; set; }
        }
    }
}
