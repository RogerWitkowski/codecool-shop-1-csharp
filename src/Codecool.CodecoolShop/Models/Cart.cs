using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Codecool.CodecoolShop.Models
{
    public class Cart : BaseModel
    {
        public List<Product> Products { get; set; }

        private static Cart instance = null;

        public static Cart GetInstance()
        {
            if (instance == null)
            {
                instance = new Cart();
            }

            return instance;
        }
    }
}