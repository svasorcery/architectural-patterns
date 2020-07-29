using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SvaSorcery.Patterns.Enterprise.Cache.Common.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.AppController.Models;

namespace SvaSorcery.Patterns.Enterprise.Presentation.AppController.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonsController : Controller
    {
        private readonly ILogger<PersonsController> _logger;
        private readonly IRepository<Person> _repository;
        private readonly ICache<Person> _cache;

        public PersonsController(
            ILogger<PersonsController> logger,
            IRepository<Person> repository,
            ICache<Person> cache)
        {
            _logger = logger;
            _repository = repository;
            _cache = cache;
        }

        [HttpGet]
        public IActionResult Index()
            => View(_repository.GetAll());

        [HttpGet("{id:int}")]
        public IActionResult Item(int id)
            => View(_cache.Get(id));

        [HttpPost]
        public IActionResult Add([FromBody] Person item)
        {
            _cache.Put(item);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person item)
        {
            _cache.Put(item);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _cache.Remove(id);
            return Ok();
        }
    }
}
