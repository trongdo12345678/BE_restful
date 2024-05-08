using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class ProductCodeDao : ProductCodeService
{
    private readonly ArtsContext _context;
    public ProductCodeDao(ArtsContext context)
    {
        _context = context;
    }
    public List<ProductCode> GetProCode()
    {
        try
        {
            var Procode = (from p in _context.ProductCodes
                            select new ProductCode
                            {
                                ProductCode1 = p.ProductCode1,
                                ProductId = p.ProductId,
                                Status = p.Status,
                                ProductNum = p.ProductNum,
                                IventoryId = p.IventoryId,
                                Product = (from pi in _context.Products
                                            where pi.ProductName == pi.ProductName
                                           select pi).FirstOrDefault(),
                                Iventory = (from pi in _context.ProductInventories
                                           where pi.Quantity == pi.Quantity
                                            select pi).FirstOrDefault()

                            }).ToList();

            return Procode;
        }
        catch (Exception)
        {
            return [];
        }
    }
}
