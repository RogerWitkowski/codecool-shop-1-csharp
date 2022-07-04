using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Codecool.CodecoolShop.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(15,ErrorMessage = "Descryption need to be min 15 chars!")]
        public string Description { get; set; }
    }
}
