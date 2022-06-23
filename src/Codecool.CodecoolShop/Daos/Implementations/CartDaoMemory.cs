using Codecool.CodecoolShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class CartDaoMemory : ICartDao
{
    private List<Product> products = new List<Product>();
    private static CartDaoMemory instance = null;

    private CartDaoMemory()
    {
    }

    public static CartDaoMemory GetInstance()
    {
        if (instance == null)
        {
            instance = new CartDaoMemory();
        }

        return instance;
    }
    public void Add(Product item)
    {
        if (products.Contains(item))
        {
            item.Quantity += 1;
        }
        else
        {
            products.Add(item);
            item.Quantity = 1;
        }

    }

    public Product Get(int id)
    {
        return products.Find(x => x.Id == id);
    }

    public void Remove(int id)
    {
        Product item = Get(id);
        if (item.Quantity >= 1)
        {
            item.Quantity -= 1;
        }
        else
        {
            products.Remove(item);
        }
    }

    public IEnumerable<Product> GetAll()
    {
        return products;
    }


    public IEnumerable<Product> GetBy(Supplier supplier)
    {
        return products.Where(x => x.Supplier.Id == supplier.Id); ;
    }

    public IEnumerable<Product> GetBy(ProductCategory productCategory)
    {
        return products.Where(x => x.ProductCategory.Id == productCategory.Id);
    }
}