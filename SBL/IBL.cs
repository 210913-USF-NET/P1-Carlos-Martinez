using System;
using System.Collections.Generic;
using System.Net.Security;
using Models;

namespace SBL
{
    public interface IBL
    {
        public Object AddObject(Object thing);
        public void UpdateObject(Object thing);
        public void RemoveObject(Object thing);
        public Customer GetOneCustomer(int Id);
        public Customer GetOneCustomer(string username);
        public List<Customer> GetAllCustomers();
        public StoreFront GetOneStoreFront(int Id);
        public StoreFront GetOneStoreFront(string storeName);
        public List<StoreFront> GetAllStoreFronts();
        public Product GetOneProduct(int Id);
        public Product GetOneProduct(string Name);
        public List<Product> GetAllProducts();
        public Inventory GetOneInventory(int Id);
        public List<Product> GetStoreInventoryDetails(int Id);
        public List<StoreFront> GetOrderStoreInfo(List<Orders> orders);
        public Orders GetOneOrder(int Id);
        public List<LineItem> GetLineItemsForOrder(int Id);

        // Password
        public string Hash(string password);
        public bool Verify(string password, string hash);

        // String
        public string CapitalizeFirstLetter(string entry);

        // Order
        public List<Orders> orderList(List<Orders> Orders, int choice);
    }
}