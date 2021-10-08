using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IProductRepo
    {
         Product AddProduct(Product productToAdd);

         Product GetProduct(Product product);

         List<Product> GetAllProducts();

         void DeleteProduct();

         Product UpdateProduct(Product productToUpdate);

    }
}