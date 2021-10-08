using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class ClientController : Controller
    {
        private IBL _bl;
        public ClientController(IBL bl)
        {
            _bl = bl;
        }
        // GET: ClientController
        public ActionResult Index()
        {
            List<Client> allClients = _bl.GetAllClients();
            return View(allClients);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            Client clientDetails = _bl.GetOneClient(id);
            return View(clientDetails);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            try
            {
                if (_bl.GetOneClient(client.FirstName, client.LastName) == null)
                {
                    client.Password = _bl.Hash(client.Password);
                    _bl.AddObject(client);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_bl.GetOneClient(id));
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Client client)
        {
            try
            {
                _bl.DeleteObject(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
