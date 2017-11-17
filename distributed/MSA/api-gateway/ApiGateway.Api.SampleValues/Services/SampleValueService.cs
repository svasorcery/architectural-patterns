using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Api.SampleValues.Services
{
    public partial class SampleValueService
    {
        // WARNING: It is a temporary repo
        // TODO: Replace with resource service http client, ref #2
        private readonly List<SampleValue> _values; 

        public SampleValueService()
        {
            _values = InitValuesRepository();
        }


        public Task<List<SampleValue>> GetValuesAsync()
        {
            return Task.FromResult(_values);
        }

        public Task<SampleValue> GetValueAsync(int id)
        {
            return Task.FromResult(_values.FirstOrDefault(v => v.Id == id));
        }

        public Task<SampleValue> CreateValueAsync(SampleValue value)
        {
            value.Id = _values.Last().Id + 1;

            _values.Add(value);

            return Task.FromResult(value);
        }

        public Task<SampleValue> UpdateValueAsync(int id, SampleValue value)
        {
            var update = _values.FirstOrDefault(v => v.Id == id);

            update.Code = value.Code;
            update.Name = value.Name;
            update.Description = value.Description;
            update.Created = value.Created;

            return Task.FromResult(update);
        }

        public Task DeleteValueAsync(int id)
        {
            _values.RemoveAt(id);
            
            return Task.FromResult(0);
        }


        private List<SampleValue> InitValuesRepository()
        {
            var creator = new SamplePerson(255, "Sinyavsky", "Vladimir");

            return new List<SampleValue>
            {
                new SampleValue
                {
                    Id = 10001,
                    Code = "val001",
                    Name = "Sample value #1",
                    Description = "Super cool sample value #1",
                    Created = new SampleEvent(creator, DateTime.Now.AddDays(-10))
                },
                new SampleValue
                {
                    Id = 10002,
                    Code = "val002",
                    Name = "Sample value #2",
                    Description = "Magnificent shiny sample value #2",
                    Created = new SampleEvent(creator, DateTime.Now.AddDays(-8))
                },
                new SampleValue
                {
                    Id = 10003,
                    Code = "val003",
                    Name = "Sample value #3",
                    Description = "Great and richly sample value #3",
                    Created = new SampleEvent(creator, DateTime.Now.AddDays(-7))
                },
                new SampleValue
                {
                    Id = 10004,
                    Code = "val004",
                    Name = "Sample value #4",
                    Description = "Never ever seen sample value #4",
                    Created = new SampleEvent(creator, DateTime.Now.AddDays(-4))
                },
                new SampleValue
                {
                    Id = 10015,
                    Code = "val015",
                    Name = "Sample value #15",
                    Description = "Top secret sample value #15",
                    Created = new SampleEvent(creator, DateTime.Now)
                }
            };
        }
    }
}
