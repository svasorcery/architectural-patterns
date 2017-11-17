namespace ApiGateway.Api.SampleValues.Services
{
    public partial class SampleValueService
    {
        public class SamplePerson
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string FullName => $"{LastName} {FirstName} {MiddleName}"?.TrimEnd();

            public SamplePerson(int id, string lastName, string firstName, string middleName = null)
            {
                Id = id;
                LastName = lastName;
                FirstName = firstName;
                MiddleName = middleName;
            }
        }
    }
}
