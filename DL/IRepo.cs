using System;
using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IRepo
    {
        public Object AddObject(Object thing);
        public void UpdateObject(Object thing);
        public void RemoveObject(Object thing);
        public Customer GetOneCustomer(int Id);
        public Customer GetOneCustomer(string username);
        public List<Customer> GetAllCustomers();
        public StoreFront GetOneStoreFront(int Id);
        public StoreFront GetOneStoreFront(string storeName);
        List<StoreFront> GetAllStoreFronts();
        public Product GetOneProduct(int Id);
        public Product GetOneProduct(string Name);
        public List<Product> GetAllProducts();
        public Inventory GetOneInventory(int Id);
        public List<Product> GetStoreInventoryDetails(int Id);
        public List<StoreFront> GetOrderStoreInfo(List<Orders> orders);
        public List<Customer> GetOrderCustomerInfo(List<Orders> orders);
        public Orders GetOneOrder(int Id);
        public List<Orders> GetAllOrders();
        public List<LineItem> GetLineItemsForOrder(int Id);
    }
}
