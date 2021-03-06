using System;
using System.Collections.Generic;
using Models;
using DL;
using System.Text.RegularExpressions;


namespace SBL
{
    public class BL : IBL

    {
        private IRepo _repo;

        public BL(IRepo repo)
        {
            _repo = repo;
        }

        public Object AddObject(Object thing)
        {
            return _repo.AddObject(thing);
        }
        public void UpdateObject(Object thing)
        {
            _repo.UpdateObject(thing);
        }
        public void RemoveObject(Object thing)
        {
            _repo.RemoveObject(thing);
        }
        public Customer GetOneCustomer(int Id)
        {
            return _repo.GetOneCustomer(Id);
        }
        public Customer GetOneCustomer(string username)
        {
            return _repo.GetOneCustomer(username);
        }
        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
        public StoreFront GetOneStoreFront(int Id)
        {
            return _repo.GetOneStoreFront(Id);
        }
        public StoreFront GetOneStoreFront(string storeName)
        {
            return _repo.GetOneStoreFront(storeName);
        }
        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }
        public Product GetOneProduct(int Id)
        {
            return _repo.GetOneProduct(Id);
        }
        public Product GetOneProduct(string Name)
        {
            return _repo.GetOneProduct(Name);
        }
        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }
        public Inventory GetOneInventory(int Id)
        {
            return _repo.GetOneInventory(Id);
        }
        public List<Product> GetStoreInventoryDetails(int Id)
        {
            return _repo.GetStoreInventoryDetails(Id);
        }
        public List<StoreFront> GetOrderStoreInfo(List<Orders> orders)
        {
            return _repo.GetOrderStoreInfo(orders);
        }
        public List<Customer> GetOrderCustomerInfo(List<Orders> orders)
        {
            return _repo.GetOrderCustomerInfo(orders);
        }

        public List<Orders> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }
        public Orders GetOneOrder(int Id)
        {
            return _repo.GetOneOrder(Id);
        }
        public List<LineItem> GetLineItemsForOrder(int Id)
        {
            return _repo.GetLineItemsForOrder(Id);
        }

        // Password Shenanigans!
        public string Hash(string password)
        {
            return PasswordHasher.Hash(password);
        }
        public bool Verify(string password, string hash)
        {
            return PasswordHasher.Verify(password, hash);
        }

        // String Shenanigans

        public string CapitalizeFirstLetter(string entry)
        {
            if (entry.Length == 1)
            {
                entry = entry.ToUpper();
            }
            else
            {
                entry = entry[0].ToString().ToUpper() + entry.Substring(1).ToLower();
            }

            return entry;
        }

        // Ordering Shenanigans
        public List<Orders> orderList(List<Orders> Orders, int choice)
        {
            // 0 is Ascending Total
            // 1 is Descending Total
            // 2 is Ascending Date
            // 3 is Descending Date
            orderComparer comparer = new orderComparer();

            switch (choice)
            {
                case 0:
                    Orders.Sort(comparer.ComparebyAscTotal);
                    break;
                case 1:
                    Orders.Sort(comparer.ComparebyDesTotal);
                    break;
                case 2:
                    Orders.Sort(comparer.ComparebyAscDate);
                    break;
                case 3:
                    Orders.Sort(comparer.ComparebyDesDate);
                    break;
            }
            return Orders;
        }
    }
}
