using System;
using System.Collections.Generic;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.Common;
using System.Threading.Tasks;

namespace DL
{
    public class DBCustomerRepo : ICustomerRepo
    {
        private Entity.P0TenzinStoreContext _context;

        public DBCustomerRepo(Entity.P0TenzinStoreContext context)
        {
            _context = context;
        }
        public Model.Order AddAnOrder(Model.Order order)
        {
            Entity.Order orderToAdd = new Entity.Order()
            {
                Total = order.Total,
                CustomerId = order.CustomerId,
                StoreFrontId = order.StoreFrontId
            };

            orderToAdd = _context.Orders.Add(orderToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Order()
            {
                Id = orderToAdd.Id,
                Total = (decimal)orderToAdd.Total,
                CustomerId = orderToAdd.CustomerId,
                StoreFrontId = orderToAdd.StoreFrontId,
                OrderDate = (DateTime)orderToAdd.OrderDate
            };
        }

        public Model.Customer AddCustomer(Model.Customer customer)
        {
            Entity.Customer customerToAdd = new Entity.Customer()
            {
                Name = customer.Name,
                Address = customer.Address,
                Email = customer.Email
            };

            customerToAdd = _context.Add(customerToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return new Model.Customer
            {
                Id = customerToAdd.Id,
                Name = customerToAdd.Name,
                Address = customerToAdd.Address,
                Email = customerToAdd.Email
            };
        }
        public Model.Product AddProduct(Model.Product product)

        {
            Entity.Product productToAdd = new Entity.Product()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category
            };

            productToAdd = _context.Add(productToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Product
            {
                Id = productToAdd.Id,
                Name = productToAdd.Name,
                Price = (decimal)productToAdd.Price,
                Description = productToAdd.Description,
                Category = productToAdd.Category
            };
        }

        public void DeleteCustomer(string email)
        {
            Entity.Customer customerToDelete = new Entity.Customer()
            {
                Email = email
            };

            customerToDelete = _context.Remove(customerToDelete).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public List<Model.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(customer => new Model.Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                Email = customer.Email
            }).ToList();
        }

        public Model.Customer GetCustomer(string name)
        {
            Entity.Customer customerByName = _context.Customers.FirstOrDefault(s => s.Name == name);

            if (customerByName == null)
            {
                return null;
            }
            else
            {
                Model.Customer returnedCustomer = new Model.Customer()
                {
                    Id = customerByName.Id,
                    Name = customerByName.Name,
                    Address = customerByName.Address,
                    Email = customerByName.Email
                };

                return returnedCustomer;

            }
        }

        public Model.Customer UpdateCustomer(Model.Customer customerToUpdate)
        {
            Entity.Customer updateCustomer = new Entity.Customer()
            {
                Id = customerToUpdate.Id,
                Name = customerToUpdate.Name,
                Address = customerToUpdate.Address,
                Email = customerToUpdate.Email
            };

            updateCustomer = _context.Customers.Update(updateCustomer).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Customer()
            {
                Id = updateCustomer.Id,
                Name = updateCustomer.Name,
                Address = updateCustomer.Address,
                Email = updateCustomer.Email
            };
        }

        public List<Model.Customer> SearchCustomer(string queryStr)
        {
            return _context.Customers.Where(
                custo => custo.Name.Contains(queryStr)).Select(
                    c => new Model.Customer()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Address = c.Address,
                        Email = c.Email
                    }
                ).ToList();
        }

        public List<Model.Product> GetAllProducts()
        {
            return _context.Products.Select(product => new Model.Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = (decimal)product.Price,
                Description = product.Description,
                Category = product.Category

            }).ToList();
        }
        public List<Model.StoreFront> GetAllStores()
        {
            return _context.StoreFronts.Select(stores => new Model.StoreFront()
            {
                Id = stores.Id,
                Name = stores.Name,
                Address = stores.Address
            }).ToList();
        }

        public List<Model.Order> GetAllOrders()
        {
            return _context.Orders.Select(order => new Model.Order()
            {
                Id = order.Id,
                Total = (decimal)order.Total,
                OrderDate = (DateTime)order.OrderDate,
                CustomerId = order.CustomerId,
                StoreFrontId = order.StoreFrontId
            }).ToList();
        }

        public List<Model.LineItems> GetLineItems()
        {
            return _context.LineItems.Select(items => new Model.LineItems()
            {
                Id = items.Id,
                Quantity = (int)items.Quantity
            }).ToList();
        }


        public List<Model.Inventory> GettAllInventories()
        {
            return _context.Inventories.Include("Product").Select(inventory => new Model.Inventory()
            {
                Quantity = (int)inventory.Quantity,
                ProductID = (int)inventory.ProductId,
                StoreID = (int)inventory.StoreId,
                Product = new Model.Product
                {
                    Id = inventory.Product.Id,
                    Name = inventory.Product.Name,
                    Description = inventory.Product.Description,
                    Price = (decimal)inventory.Product.Price,
                    Category = inventory.Product.Category
                }
            }).ToList();
        }


        public Model.Product UpdateProduct(Model.Product productToUpdate)
        {
            Entity.Product updateProduct = new Entity.Product()
            {
                Id = productToUpdate.Id,
                Name = productToUpdate.Name,
                Price = productToUpdate.Price,
                Description = productToUpdate.Description,
                Category = productToUpdate.Category
            };

            updateProduct = _context.Products.Update(updateProduct).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Product()
            {
                Id = updateProduct.Id,
                Name = updateProduct.Name,
                Price = (decimal)updateProduct.Price,
                Description = updateProduct.Description,
                Category = updateProduct.Category
            };
        }

        public Model.StoreFront SelectStore(int id)
        {
            Entity.StoreFront storeById = _context.StoreFronts.Include("LineItems").FirstOrDefault(s => s.Id == id);

            return new Model.StoreFront()
            {
                Id = storeById.Id,
                Name = storeById.Name,
                Address = storeById.Address,
                // Inventory = storeById.Inventories.Select(i => new Model.Inventory()
                // {
                //     Id = i.Id,
                //     Quantity = (int)i.Quantity,
                //     ProductID = (int)i.ProductId,
                //     StoreID = (int)i.StoreId
                // }).ToList()
            };
        }

        public Model.StoreFront AddStore(Model.StoreFront storeFront)
        {
            Entity.StoreFront storeToAdd = new Entity.StoreFront()
            {
                Name = storeFront.Name,
                Address = storeFront.Address
            };

            storeToAdd = _context.Add(storeToAdd).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return new Model.StoreFront()
            {
                Id = storeToAdd.Id,
                Name = storeToAdd.Name,
                Address = storeToAdd.Address
            };
        }

        public Model.LineItems AddLineItem(Model.LineItems lineItems)
        {
            Entity.LineItem itemToAdd = new Entity.LineItem()
            {
                Quantity = (int)lineItems.Quantity,
                ProductId = lineItems.ProductId,
                OrderId = lineItems.OrderId
            };

            itemToAdd = _context.Add(itemToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.LineItems()
            {
                Id = itemToAdd.Id,
                Quantity = (int)itemToAdd.Quantity,
                ProductId = (int)itemToAdd.ProductId,
                OrderId = (int)itemToAdd.OrderId
            };
        }

        public Model.Inventory AddInventory(Model.Inventory inventory)
        {
            Entity.Inventory inventoryToAdd = new Entity.Inventory()
            {
                Quantity = inventory.Quantity,
                ProductId = inventory.ProductID,
                StoreId = inventory.StoreID
            };

            inventoryToAdd = _context.Add(inventoryToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Inventory()
            {
                Id = inventoryToAdd.Id,
                Quantity = (int)inventoryToAdd.Quantity,
                ProductID = (int)inventoryToAdd.ProductId,
                StoreID = (int)inventoryToAdd.StoreId
            };
        }

        public List<Model.Inventory> GetInventoriesByStoreId(int storeId)
        {
            return _context.Inventories.Where(inv => inv.StoreId == storeId).Select(newInv => new Model.Inventory()
            {
                Id = newInv.Id,
                StoreID = (int)newInv.StoreId,
                Quantity = (int)newInv.Quantity,
                ProductID = (int)newInv.ProductId
            }).ToList();
        }

        public Model.Product GetProductById(int productId)
        {
            Entity.Product productById = _context.Products.FirstOrDefault(p => p.Id == productId);

            return new Model.Product()
            {
                Id = productById.Id,
                Name = productById.Name,
                Price = (decimal)productById.Price,
                Description = productById.Description,
                Category = productById.Category
            };
        }

        public Model.Inventory UpdateInventory(Model.Inventory inventoryToUpdate)
        {
            Entity.Inventory updateInventory = new Entity.Inventory()
            {
                Id = inventoryToUpdate.Id,
                StoreId = inventoryToUpdate.StoreID,
                ProductId = inventoryToUpdate.ProductID,
                Quantity = inventoryToUpdate.Quantity,
            };

            updateInventory = _context.Inventories.Update(updateInventory).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Inventory()
            {
                // Id = updateInventory.Id,
                StoreID = (int)updateInventory.StoreId,
                ProductID = (int)updateInventory.ProductId
            };
        }

        public Model.Order UpdateOrder(Model.Order orderToUpdate)
        {
            Entity.Order updateOrder = new Entity.Order()
            {
                Id = orderToUpdate.Id,
                Total = orderToUpdate.Total,
                CustomerId = orderToUpdate.CustomerId,
                StoreFrontId = orderToUpdate.StoreFrontId,
                OrderDate = orderToUpdate.OrderDate
            };

            updateOrder = _context.Orders.Update(updateOrder).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Order()
            {
                Id = updateOrder.Id,
                Total = (decimal)updateOrder.Total,
                CustomerId = updateOrder.CustomerId,
                StoreFrontId = updateOrder.StoreFrontId,
                OrderDate = orderToUpdate.OrderDate
            };
        }
    }
}