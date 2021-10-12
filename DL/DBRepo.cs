using System;
using System.Collections.Generic;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.Common;
using System.Threading.Tasks;

namespace DL
{
    public class DBRepo : IRepo
    {
        private ElephantDBContext _context;

        public DBRepo(ElephantDBContext context)
        {
            _context = context;
        }

        // Generic Methods (Create, Remove, and Update)
        public Object AddObject(Object thing)
        {
            /// Adds an object to the appropriate database. 
            /// thing is the object being added
            
            thing = _context.Add(thing).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return thing;
        }
        public void RemoveObject(Object thing)
        {
            /// Removes an object

            _context.Remove(thing);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        public void UpdateObject(Object thing)
        {
            /// Updates an object in the appropriate database. 
            /// thing is the object being updated

            _context.Update(thing);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        
        // Customer Methods
        public Customer GetOneCustomer(int Id)
        {
            /// Gets one client from all the customers
            /// Id is the ID of the customer you want

            Customer customer = _context.Customers
                .Where(i => i.Id == Id)
                .Select(
                c => new Customer()
                {
                    Id = c.Id,
                    Username = c.Username,
                    Password = c.Password,
                    Credit = c.Credit,
                    CustomerOrders = c.CustomerOrders
                }
                ).SingleOrDefault();

            foreach(var item in customer.CustomerOrders)
            {
                item.OrderLines = GetLineItemsForOrder(item.Id);
            }

            if (customer is not null)
                return customer;
            else
                return null;
        }
        public Customer GetOneCustomer(string username)
        {
            /// Gets one client from all the customers
            /// Username is the username of the customer you want

            Customer customer = _context.Customers
                .Where(i => i.Username == username)
                .Select(
                c => new Customer()
                {
                    Id = c.Id,
                    Username = c.Username,
                    Password = c.Password,
                    Credit = c.Credit,
                    CustomerOrders = c.CustomerOrders
                }
                ).SingleOrDefault();

            foreach (var item in customer.CustomerOrders)
            {
                item.OrderLines = GetLineItemsForOrder(item.Id);
            }

            if (customer is not null)
                return customer;
            else
                return null;
        }
        public List<Customer> GetAllCustomers()
        {
            /// Gets all the clients in a list
            
            return _context.Customers
                .Select(
                c => new Customer()
                {
                    Id = c.Id,
                    Username = c.Username,
                    Password = c.Password,
                    Credit = c.Credit,
                    CustomerOrders = c.CustomerOrders
                }
            ).ToList();
        }

        // StoreFront Methods
        public StoreFront GetOneStoreFront(int Id)
        {
            /// Gets one client from all the customers
            /// Id is the ID of the customer you want

            StoreFront storefront = _context.StoreFronts
                .Where(i => i.Id == Id)
                .Select(
                c => new StoreFront()
                {
                    Id = c.Id,
                    StoreName = c.StoreName,
                    storeInventory = c.storeInventory,
                    storeOrders = c.storeOrders
                }
                ).SingleOrDefault();

            if (storefront is not null)
                return storefront;
            else
                return null;
        }
        public StoreFront GetOneStoreFront(string storeName)
        {
            /// Gets one client from all the customers
            /// Id is the ID of the customer you want

            StoreFront storefront = _context.StoreFronts
                .Where(i => i.StoreName == storeName)
                .Select(
                c => new StoreFront()
                {
                    Id = c.Id,
                    StoreName = c.StoreName,
                    storeInventory = c.storeInventory,
                    storeOrders = c.storeOrders
                }
                ).SingleOrDefault();

            if (storefront is not null)
                return storefront;
            else
                return null;
        }
        public List<StoreFront> GetAllStoreFronts()
        {
            /// Gets all the clients in a list

            return _context.StoreFronts
                .Select(
                s => new StoreFront()
                {
                    Id = s.Id,
                    StoreName = s.StoreName,
                    storeInventory = s.storeInventory,
                    storeOrders = s.storeOrders
                }
            ).ToList();
        }

        // Product Methods
        public Product GetOneProduct(int Id)
        {
            /// Gets one client from all the customers
            /// Id is the ID of the customer you want

            Product product = _context.Products
                .Where(i => i.Id == Id)
                .Select(
                c => new Product()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Description = c.Description
                }
                ).SingleOrDefault();

            if (product is not null)
                return product;
            else
                return null;
        }
        public Product GetOneProduct(string Name)
        {
            /// Gets one client from all the customers
            /// Id is the ID of the customer you want

            Product product = _context.Products
                .Where(i => i.Name == Name)
                .Select(
                c => new Product()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Description = c.Description
                }
                ).SingleOrDefault();

            if (product is not null)
                return product;
            else
                return null;
        }
        public List<Product> GetAllProducts()
        {
            /// Gets all the clients in a list

            return _context.Products
                .Select(
                s => new Product()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    Description = s.Description
                }
            ).ToList();
        }

        // Inventory Methods
        public Inventory GetOneInventory(int Id)
        {
            Inventory inventory = _context.Inventory
                .Where(i => i.Id == Id)
                .Select(
                c => new Inventory()
                {
                    Id = c.Id,
                    ProductId = c.ProductId,
                    StoreFrontId = c.StoreFrontId,
                    Quantity = c.Quantity
                }
                ).SingleOrDefault();

            if (inventory is not null)
                return inventory;
            else
                return null;
        }
        public List<Product> GetStoreInventoryDetails(int Id)
        {
            List<Inventory> relevantInventory = GetOneStoreFront(Id).storeInventory;

            List<Product> relevantProducts = new List<Product>();

            foreach(var item in relevantInventory)
            {
                relevantProducts.Add(GetOneProduct(item.ProductId));
            }

            return relevantProducts;
        }
        
        // Order Methods
        public List<StoreFront> GetOrderStoreInfo(List<Orders> orders)
        {
            List<StoreFront> relevantStores = new List<StoreFront>();
            foreach(var item in orders)
            {
                relevantStores.Add(GetOneStoreFront(item.StoreFrontId));
            }

            return relevantStores;
        }
        public Orders GetOneOrder(int Id)
        {
            Orders order = _context.Orders
                .Where(i => i.Id == Id)
                .Select(
                c => new Orders()
                {
                    Id = c.Id,
                    Date = c.Date,
                    Total = c.Total,
                    CustomerId = c.CustomerId,
                    StoreFrontId = c.StoreFrontId,
                    OrderLines = c.OrderLines
                }
                ).SingleOrDefault();

            order.OrderLines = GetLineItemsForOrder(order.Id);

            if (order is not null)
                return order;
            else
                return null;
        }
        
        // Line Item Methods
        public List<LineItem> GetLineItemsForOrder(int Id)
        {
            return _context.LineItem
                .Where(i => i.OrderId == Id)
                .Select(
                c => new LineItem()
                {
                    Id = c.Id,
                    OrderId = c.OrderId,
                    Product = c.Product,
                    Quantity = c.Quantity
                }
                ).ToList();
        }
    }
}