using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class StockProductDao : StockProductService
{
    private readonly ArtsContext _context;
    public StockProductDao(ArtsContext context)
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
