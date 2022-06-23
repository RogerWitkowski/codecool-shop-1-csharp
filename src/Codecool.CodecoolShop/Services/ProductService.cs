using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
        public readonly ICartDao cartDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ICartDao cartDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
            this.cartDao = cartDao;
        }

        public ProductCategory GetProductCategory(int categoryId)
        {
            return this.productCategoryDao.Get(categoryId);
        }
        public IEnumerable<Product> GetCart()
        {
            return this.cartDao.GetAll();
        }

        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            ProductCategory category = this.productCategoryDao.Get(categoryId);
            return this.productDao.GetBy(category);
        }
    }
}
