using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codecool.DataAccess.Repository.IRepository;
using Codecool.Models;

namespace Codecool.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Product objProduct)
        {
            var objProductFromDb = _db.Products.FirstOrDefault(p => p.Id == objProduct.Id);
            if (objProductFromDb != null)
            {
                objProductFromDb.Name = objProduct.Name;
                objProductFromDb.Description = objProduct.Description;
                objProductFromDb.DefaultPrice = objProduct.DefaultPrice;
                objProductFromDb.CategoryId = objProduct.CategoryId;
                objProductFromDb.Quantity = objProduct.Quantity;
                if (objProduct.ImageUrl != null)
                {
                    objProductFromDb.ImageUrl = objProduct.ImageUrl;
                }
            }
        }
    }
}
