using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SBL;
using Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBL _bl;
        static Client CurrentClient;

        public HomeController(IBL bl)
        {
            _bl = bl;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Client client)
        {
            if (_bl.GetOneClient(client.FirstName, client.LastName) != null)
            {
                CurrentClient = _bl.GetOneClient(client.FirstName, client.LastName);
            }
            return View();
        }

        public ActionResult StrengthCard(Client client)
        {
            List<Weight> weights = _bl.GetWeights(client);
            return View(weights);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
