using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Views.Persistence;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Views.Serialization;

namespace SvaSorcery.Patterns.Enterprise.Presentation.TwoStepView.Controllers
{
    public class HomeController : Controller
    {
        protected readonly SimpleXmlSerializer _serializer;

        public HomeController()
        {
            _serializer = new SimpleXmlSerializer();
        }

        public IActionResult Table()
        {
            ViewBag.Persons = RetrievePersonsAndSerialize();
            return View();
        }

        public IActionResult List()
        {
            ViewBag.Persons = RetrievePersonsAndSerialize();
            return View();
        }

        public IActionResult Details(int id)
        {
            var person = PersonsRepository.GetAll().FirstOrDefault(x => x.Id == id);

            if (person is null)
                return NotFound();

            return View(person);
        }

        protected string RetrievePersonsAndSerialize()
        {
            var persons = PersonsRepository.GetAll();
            return _serializer.Serialize(persons, System.Text.Encoding.UTF8);
        }
    }
}
