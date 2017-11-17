using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Clients.MvcAngular.Models;

namespace ApiGateway.Clients.MvcAngular.Controllers
{
    [Route("api/[controller]")]
    public class SampleValuesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromQuery]int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody]SampleValue model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromQuery]int id, [FromBody]SampleValue model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery]int id)
        {
            return Ok();
        }
    }
}
