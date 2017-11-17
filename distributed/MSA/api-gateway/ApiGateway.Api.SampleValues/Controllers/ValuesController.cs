using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Api.SampleValues.Controllers
{
    using ApiGateway.Api.SampleValues.Services;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly SampleValueService _client;

        public ValuesController(SampleValueService client)
        {
            _client = client;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _client.GetValuesAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _client.GetValueAsync(id));
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SampleValueService.SampleValue value)
        {
            return Ok(await _client.CreateValueAsync(value));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromQuery]int id, [FromBody]SampleValueService.SampleValue value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            return Ok(await _client.UpdateValueAsync(id, value));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            await _client.DeleteValueAsync(id);

            return Ok("deleted");
        }
    }
}
