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

            thing = _context.Update(thing).Entity;
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
    }
}