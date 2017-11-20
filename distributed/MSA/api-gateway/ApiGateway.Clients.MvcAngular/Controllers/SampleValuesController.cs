using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Clients.MvcAngular.Controllers
{
    using ApiGateway.Clients.MvcAngular.Models;
    using ApiGateway.Clients.MvcAngular.Services;

    [Route("api/[controller]")]
    public class SampleValuesController : Controller
    {
        private readonly SampleValuesApiClient _client;

        public SampleValuesController(SampleValuesApiClient client)
        {
            _client = client;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _client.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return Ok(await _client.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]SampleValue model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(await _client.CreateAsync(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody]SampleValue model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(await _client.UpdateAsync(id, model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _client.DeleteAsync(id);
            return Ok(true);
        }
    }
}
