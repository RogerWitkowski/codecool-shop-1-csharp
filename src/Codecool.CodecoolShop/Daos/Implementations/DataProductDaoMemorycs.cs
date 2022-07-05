using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class DataProductDaoMemorycs
    {
        public  IEnumerable<Product> Products = ProductDaoMemory.GetInstance().GetAll();

        public IEnumerable<ProductCategory> Category = ProductCategoryDaoMemory.GetInstance().GetAll();

        public IEnumerable<Supplier> Suppliers =SupplierDaoMemory.GetInstance().GetAll();

    }
}
