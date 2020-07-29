using Microsoft.AspNetCore.Mvc;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Views.Persistence;

namespace SvaSorcery.Patterns.Enterprise.Presentation.TemplateView.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var persons = PersonsRepository.GetAll();

            return View(persons);
        }
    }
}
