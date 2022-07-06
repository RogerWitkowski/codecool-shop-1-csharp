using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Codecool.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(15, ErrorMessage = "Descryption need to be min 15 chars!")]
        public string Description { get; set; }
        [DisplayName("Price")]
        [Required]
        public double DefaultPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Display(Name = "Product Picture")]
        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

    }
}
