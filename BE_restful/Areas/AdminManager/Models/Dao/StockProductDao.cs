using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class StockProductDao : StockProductService
{
    private readonly ArtsDbContext _context;
    public StockProductDao(ArtsDbContext context)
    {
        _context = context;
    }
    public List<Product> GetOrderDetail()
    {
        try
        {
            var stockPro = (from pi in _context.Products
                            select new Product
                            {
                                CategoryId = pi.CategoryId,
                                ProductName = pi.ProductName,
                                QuantityAvailable = pi.QuantityAvailable,
                                Price = pi.Price,
                                Category = (from p in _context.ProductCategories
                                            where p.CategoryId == pi.CategoryId
                                            select p).FirstOrDefault()

                            }).ToList();

            return stockPro;
        }
        catch (Exception)
        {
            return [];
        }
    }
}
