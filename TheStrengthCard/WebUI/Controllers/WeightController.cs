﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class WeightController : Controller
    {
        // GET: WeightController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WeightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeightController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: WeightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeightController/Edit/5
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

        // GET: WeightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}