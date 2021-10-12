using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using SBL;
using System.Dynamic;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBL _bl;

        public AdminController(IBL bl)
        {
            _bl = bl;
        }
        public ActionResult Index(int i)
        {
            switch (i)
            {
                case 1:
                    return RedirectToAction("StoreIndex");
                case 2:
                    return RedirectToAction("ProductIndex");
                case 3:
                    return RedirectToAction("CustomerIndex");
            }
            return View();
        }

        // Store
        public ActionResult StoreIndex()
        {
            List<StoreFront> allStores = _bl.GetAllStoreFronts();
            return View(allStores);
        }
        public ActionResult StoreCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StoreCreate(StoreFront store)
        {
            try
            {
                // if data is valid
                if (ModelState.IsValid)
                {
                    // store.StoreName = _bl.CapitalizeFirstLetter(store.StoreName);

                    _bl.AddObject(store);
                    return RedirectToAction(nameof(StoreIndex));
                }
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public ActionResult StoreEdit(int id)
        {
            return View(_bl.GetOneStoreFront(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StoreEdit(int id, StoreFront store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.UpdateObject(store);
                    return RedirectToAction(nameof(StoreIndex));
                }
                return RedirectToAction(nameof(StoreEdit));
            }
            catch
            {
                return RedirectToAction(nameof(StoreEdit));
            }
        }
        public ActionResult StoreDetails(int id)
        {
            StoreFront activeStore = _bl.GetOneStoreFront(id);
            Response.Cookies.Append("ActiveStore", activeStore.StoreName);

            dynamic model = new ExpandoObject();
            model.Store = activeStore;
            model.Products = _bl.GetStoreInventoryDetails(id);
            return View(model);
        }
        public ActionResult StoreInventoryCreate()
        {
            //dynamic InventoryProduct = new ExpandoObject();
            //InventoryProduct.Products = _bl.GetAllProducts();
            //InventoryProduct.Inventory = _bl.GetOneStoreFront(Request.Cookies["ActiveStore"]);
            //return View(InventoryProduct);

            return View(_bl.GetAllProducts());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StoreInventoryCreate(string ProductName, string Quantity)
        {
            try
            {
                // if data is valid
                if (ModelState.IsValid)
                {
                    Product product = _bl.GetOneProduct(ProductName);
                    StoreFront store = _bl.GetOneStoreFront(Request.Cookies["ActiveStore"]);
                    Inventory inventory = new Inventory(product.Id, store.Id, Int32.Parse(Quantity));
                    _bl.AddObject(inventory);
                    return RedirectToAction(nameof(StoreIndex));
                }
                return View();
            }
            catch (Exception e)
            {
                return View(_bl.GetAllProducts());
            }
        }
        public ActionResult EditInventory(int id)
        {
            Inventory inventory = _bl.GetOneInventory(id);
            Product product = _bl.GetOneProduct(inventory.ProductId);
            dynamic Model = new ExpandoObject();
            Model.Name = product.Name;
            Model.Price = product.Price;
            Model.Quantity = inventory.Quantity;
            return View(Model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInventory(int id, int Quantity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Inventory inventory = _bl.GetOneInventory(id);
                    inventory.Quantity = Quantity;
                    _bl.UpdateObject(inventory);
                    return RedirectToAction(nameof(StoreIndex));
                }
                return RedirectToAction(nameof(StoreEdit));
            }
            catch
            {
                return RedirectToAction(nameof(StoreEdit));
            }
        }
        public ActionResult DeleteInventory(int Id)
        {
            return View(_bl.GetOneInventory(Id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInventory(int id, Inventory inventory)
        {
            try
            {
                _bl.RemoveObject(inventory);
                return RedirectToAction(nameof(StoreDetails));
            }
            catch
            {
                return View();
            }
        }
        // Products
        public ActionResult ProductIndex()
        {
            List<Product> allProducts = _bl.GetAllProducts();
            return View(allProducts);
        }
        public ActionResult ProductCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductCreate(Product product)
        {
            try
            {
                // if data is valid
                if (ModelState.IsValid)
                {
                    _bl.AddObject(product);
                    return RedirectToAction(nameof(ProductIndex));
                }
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public ActionResult ProductEdit(int id)
        {
            return View(_bl.GetOneProduct(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit(int id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.UpdateObject(product);
                    return RedirectToAction(nameof(ProductIndex));
                }
                return RedirectToAction(nameof(ProductEdit));
            }
            catch
            {
                return RedirectToAction(nameof(ProductEdit));
            }
        }
        
        // Customers
        public ActionResult CustomerIndex()
        {
            List<Customer> allCustomers = _bl.GetAllCustomers();
            return View(allCustomers);
        }
        public ActionResult CustomerCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerCreate(Customer customer)
        {
            try
            {
                // if data is valid
                if (ModelState.IsValid)
                {
                    _bl.AddObject(customer);
                    return RedirectToAction(nameof(CustomerIndex));
                }
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public ActionResult CustomerEdit(int id)
        {
            return View(_bl.GetOneCustomer(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerEdit(int id, Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.UpdateObject(customer);
                    return RedirectToAction(nameof(CustomerIndex));
                }
                return RedirectToAction(nameof(CustomerEdit));
            }
            catch
            {
                return RedirectToAction(nameof(CustomerEdit));
            }
        }
        public ActionResult CustomerDetails(int id)
        {
            // id = Customer ID
            Customer custo = new Customer();
            if (id == 0)
            {
                custo = _bl.GetOneCustomer(Request.Cookies["ActiveCustomer"]);
            }
            else
            {
                custo = _bl.GetOneCustomer(id);
                Response.Cookies.Append("ActiveCustomer", custo.Username);
            }

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
    }
}
