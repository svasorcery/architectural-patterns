using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Clients.MvcAngular.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Authorize()
        {
            return View();
        }
    }
}
