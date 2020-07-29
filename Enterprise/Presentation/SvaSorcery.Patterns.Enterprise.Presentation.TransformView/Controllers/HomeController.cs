using Microsoft.AspNetCore.Mvc;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Views.Persistence;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Views.Serialization;

namespace SvaSorcery.Patterns.Enterprise.Presentation.TransformView.Controllers
{
    public class HomeController : Controller
    {
        protected readonly SimpleXmlSerializer _serializer;

        public HomeController()
        {
            _serializer = new SimpleXmlSerializer();
        }

        public IActionResult Index()
        {
            var persons = PersonsRepository.GetAll();

            var personsXml = _serializer.Serialize(persons, System.Text.Encoding.UTF8);

            ViewBag.Persons = personsXml;

            return View();
        }
    }
}
