using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using SBL;
using Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBL _bl;

        public HomeController(IBL bl)
        {
            _bl = bl;
        }

        public ActionResult Login()
        {
            return View();
        }

        static Client CurrentClient;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Client client)
        {
            Client checked = _bl.GetOneClient(client.FirstName, client.LastName);
            if(client != null)
            {
                CurrentClient = checked;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
