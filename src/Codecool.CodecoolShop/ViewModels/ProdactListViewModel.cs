using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.ViewModels
{
    public class ProdactListViewModel
    {
        public List<Product> Products { get; set; }

        public List<Supplier> Suppliers { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }

    }
}
