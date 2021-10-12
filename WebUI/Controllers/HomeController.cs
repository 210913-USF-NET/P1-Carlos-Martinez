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
using Microsoft.AspNetCore.Http;
using Serilog;

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
                        Log.Information("The admin has signed on.");
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
                            Log.Information($"{username} has logged in.");
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
                        Log.Information($"We have a new friend, they are called {username}.");
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
            dynamic model = new ExpandoObject();
            model.Store = storeSelected;
            model.Products = _bl.GetStoreInventoryDetails(storeSelected.Id);
            return View(model);
        }
        public ActionResult SortOrders(int direction, int sort)
        {
            Customer custo = _bl.GetOneCustomer(Request.Cookies["ActiveCustomer"]);
            dynamic model = new ExpandoObject();
            model.Orders = _bl.orderList(custo.CustomerOrders, direction + sort);
            model.Stores = _bl.GetOrderStoreInfo(custo.CustomerOrders);
            return View("ShowOrderHistory", model);
        }
        public ActionResult ShowOrderHistory()
        {
            Customer custo = _bl.GetOneCustomer(Request.Cookies["ActiveCustomer"]);

            dynamic model = new ExpandoObject();
            // Orders, Total, StoreID, Time
            model.Orders = custo.CustomerOrders;
            model.Stores = _bl.GetOrderStoreInfo(custo.CustomerOrders);
            return View(model);
        }
        public ActionResult OrderDetails(int id)
        {
            // ID is the OrderID
            Orders order = _bl.GetOneOrder(id);
            return View(order);
        }
        public ActionResult CreateOrder()
        {
            StoreFront storeSelected = _bl.GetOneStoreFront(Request.Cookies["ActiveStore"]);
            dynamic model = new ExpandoObject();
            model.Store = storeSelected;
            model.Products = _bl.GetStoreInventoryDetails(storeSelected.Id);
            return View("StoreInventory", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(IFormCollection form)
        {
            Log.Information("An order is being created...");
            StoreFront storeSelected = _bl.GetOneStoreFront(Request.Cookies["ActiveStore"]);
            Customer customer = _bl.GetOneCustomer(Request.Cookies["ActiveCustomer"]);
            Orders order = new Orders();
            order.CustomerId = customer.Id;
            order.StoreFrontId = storeSelected.Id;
            order = (Orders) _bl.AddObject(order);

            foreach (var key in form)
            {
                if (key.Key == "__RequestVerificationToken")
                {
                    break;
                }
                int AmountPurchased;
                // AmountPurchased is the QUANTITY for the LineItem
                if (key.Value == "")
                    AmountPurchased = 0;
                else
                {
                    AmountPurchased = Int32.Parse(key.Value);
                }

                if (AmountPurchased == 0)
                {
                    continue;
                }

                // Product is the full product object
                Product product = _bl.GetOneProduct(int.Parse(key.Key));

                LineItem item = new LineItem(order.Id, product, AmountPurchased);

                order.OrderLines.Add(item);
                order.Total += item.Quantity * product.Price;
            }

            _bl.UpdateObject(order);

            List<StoreFront> allStores = _bl.GetAllStoreFronts();
            Log.Information("An order was created.");
            return View("Home", allStores);
        }
    }
}
