using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SBL;
using Models;
using System.Dynamic;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if ((username == "admin") && (password == "admin"))
                    {
                        // change this to redirect to the admin controller and admin index
                        return RedirectToAction("Index", "Admin");
                    }
                    if (username.Length == 1)
                    {
                        username = username.ToUpper();
                    }
                    else
                    {
                        username = username[0].ToString().ToUpper() + username.Substring(1).ToLower();
                    }

                    Customer customer = _bl.GetOneCustomer(username);
                    if (customer != null)
                    {
                        string realPassword = customer.Password;
                        // Send the input password and the proper hash of the password to the Verify Method
                        bool Verified = _bl.Verify(password, realPassword);

                        if (Verified)
                        {
                            Response.Cookies.Append("ActiveCustomer", username);
                            return RedirectToAction(nameof(Home));
                        }
                    }
                }
                return View();
            }
            catch(Exception e)
            {
                
                return View();
            }
        }

        public ActionResult SignUp(string username, string password)
        {

            if (username is not null && password is not null)
            {
                try
                {
                    if (username.Length == 1)
                    {
                        username = username.ToUpper();
                    }
                    else
                    {
                        username = username[0].ToString().ToUpper() + username.Substring(1).ToLower();
                    }

                    if (ModelState.IsValid)
                    {
                        Customer newCustomer = new Customer(username, _bl.Hash(password));
                        Response.Cookies.Append("ActiveCustomer", username);
                        _bl.AddObject(newCustomer);
                        return RedirectToAction(nameof(Home));
                    }
                    return View();
                }
                catch (Exception e)
                {

                    return View();
                }
            }
            return View();
        }

        public ActionResult ShowInventory(int Id)
        {
            StoreFront storeSelected = _bl.GetOneStoreFront(Id);
            Response.Cookies.Append("ActiveStore", storeSelected.StoreName);

            return RedirectToAction(nameof(StoreInventory));
        }

        public ActionResult Home()
        {
            List<StoreFront> allStores = _bl.GetAllStoreFronts();
            return View(allStores);
        }
        public ActionResult StoreInventory()
        {
            StoreFront storeSelected = _bl.GetOneStoreFront(Request.Cookies["ActiveStore"]);
            List<Product> allProducts = _bl.GetAllProducts();
            dynamic model = new ExpandoObject();
            model.Store = storeSelected;
            model.Products = allProducts;
            return View(model);
        }
    }
}
