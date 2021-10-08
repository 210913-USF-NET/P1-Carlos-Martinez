using System.Collections.Generic;
using DL;
using Models;

namespace StoreBL
{
    public class ProductBL
    {
        private IProductRepo _repo;

        public ProductBL(IProductRepo repo)
        {
            _repo = repo;
        }

        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }
    }
}