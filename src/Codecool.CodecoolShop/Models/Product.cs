using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codecool.CodecoolShop.Models
{
    public class Product : BaseModel
    {
        public string Currency { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayName("Price")]
        [Required]
        public decimal DefaultPrice { get; set; }
        [DisplayName("Category")]
        public ProductCategory ProductCategory { get; set; }
        public Supplier Supplier { get; set; }
        [Required]
        public int Quantity { get; set; }
        public void SetProductCategory(ProductCategory productCategory)
        {
            ProductCategory = productCategory;
            ProductCategory.Products.Add(this);
        }
    }
}
