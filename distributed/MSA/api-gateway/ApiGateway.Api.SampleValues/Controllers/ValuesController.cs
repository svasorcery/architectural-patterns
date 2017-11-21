using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace ApiGateway.Api.SampleValues.Controllers
{
    using ApiGateway.Api.SampleValues.Services;

    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly SampleValueService _client;
        private readonly ILogger _logger;

        public ValuesController(SampleValueService client, ILogger<ValuesController> logger)
        {
            _client = client;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Requesting all values");

            return Ok(await _client.GetValuesAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            _logger.LogInformation("Requesting value {Id}", id);

            var value = await _client.GetValueAsync(id);

            if (value == null)
            {
                _logger.LogWarning("Can't find value {id}", id);
            }

            return Ok(value);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SampleValueService.SampleValue value)
        {
            if (value == null)
            {
                _logger.LogWarning("Can't create, value is null");

                return BadRequest();
            }

            _logger.LogInformation("Creating value {Code} {Name}", value.Code, value.Name);

            return Ok(await _client.CreateValueAsync(value));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody]SampleValueService.SampleValue value)
        {
            if (value == null)
            {
                _logger.LogWarning("Can't update, value is null");

                return BadRequest();
            }

            _logger.LogInformation("Updating value {Id}", id);

            return Ok(await _client.UpdateValueAsync(id, value));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            _logger.LogInformation("Deleting value {Id}", id);

            await _client.DeleteValueAsync(id);

            return Ok("deleted");
        }
    }
}
