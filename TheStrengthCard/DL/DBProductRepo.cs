using System.Collections.Generic;
using Model = Models;
using Entity = DL.Entities;
using System.Linq;
using DL.Entities;
using System.Data.Common;

namespace DL
{
    public class DBProductRepo : IProductRepo
    {
        private Entity.P0TenzinStoreContext _context;

        public DBProductRepo(Entity.P0TenzinStoreContext context)
        {
            _context = context;
        }
        public Model.Product AddProduct(Model.Product productToAdd)
        {
            Entity.Product addedProduct = new Entity.Product()
            {
                Name = productToAdd.Name,
                Price = productToAdd.Price,
                Description = productToAdd.Description,
                Category = productToAdd.Category
            };

            addedProduct = _context.Add(addedProduct).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Product
            {
                Id = addedProduct.Id,
                Name = addedProduct.Name,
                Price = (decimal)addedProduct.Price,
                Description = addedProduct.Description,
                Category = addedProduct.Category
            };

        }

        public void DeleteProduct()
        {
            throw new System.NotImplementedException();
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

        public Model.Product GetProduct(Model.Product product)
        {
            throw new System.NotImplementedException();
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
                Name =updateProduct.Name,
                Price = (decimal)updateProduct.Price,
                Description = updateProduct.Description,
                Category = updateProduct.Category
            };

        }
    }
}