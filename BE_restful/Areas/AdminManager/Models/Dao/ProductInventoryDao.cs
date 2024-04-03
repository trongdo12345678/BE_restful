using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class ProductInventoryDao : ProductInventoryService
{
    private readonly ArtsDbContext _context;
    public ProductInventoryDao(ArtsDbContext context)
    {
        _context = context;
    }
    public List<Product> GetPro()
    {
        try
        {
            var res = _context.Products.ToList();
            if (res != null)
            {
                return res;
            }
            return [];
        }
        catch (Exception)
        {
            return [];
        }
    }
    public bool AddProInven(ProductInventory ProInven)
    {
        try
        {
            _context.ProductInventories.Add(ProInven);
            ProInven.DayInventory = DateOnly.FromDateTime(DateTime.Now);
            bool savedSuccessfully = _context.SaveChanges() > 0;

            if (savedSuccessfully)
            {
                var product = _context.Products.Find(ProInven.ProductId);
                if (product != null)
                {
                    product.QuantityAvailable += ProInven.Quantity;
                    _context.SaveChanges();
                }
            }

            return savedSuccessfully;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<ProductInventory> GetAllProInven()
    {
        try
        {
            var res = _context.ProductInventories.ToList();
            if (res != null)
            {
                return res;
            }
            return [];
        }
        catch (Exception)
        {
            return [];
        }
    }
    public List<ProductInventory> GetProInven()
    {
        try
        {
            var productInventories = (from pi in _context.ProductInventories
                                      select new ProductInventory
                                      {
                                          InventoryId = pi.InventoryId,
                                          ProductId = pi.ProductId,
                                          Quantity = pi.Quantity,
                                          DayInventory = pi.DayInventory,
                                          Product = (from p in _context.Products
                                                     where p.ProductId == pi.ProductId
                                                     select p).FirstOrDefault()
                                      }).ToList();

            return productInventories;
        }
        catch (Exception)
        {
            return [];
        }
    }




}
