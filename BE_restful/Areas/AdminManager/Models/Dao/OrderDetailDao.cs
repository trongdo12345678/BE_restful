using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class OrderDetailDao : OrderDetailService
{
    private readonly ArtsDbContext _context;
    public OrderDetailDao(ArtsDbContext context)
    {
        _context = context;
    }
    public List<OrderDetail> GetOrderDetail()
    {
        try
        {
            var detail = (from pi in _context.OrderDetails
                          select new OrderDetail
                          {
                              OrderDetailId = pi.OrderDetailId,
                              OrderId = pi.OrderId,
                              ProductId = pi.ProductId,
                              Quantity = pi.Quantity,
                              WarrantyStartDate = pi.WarrantyStartDate,
                              IsReturned = pi.IsReturned,
                              UnitPrice = pi.UnitPrice,
                              Order = (from p in _context.Orders
                                       where p.OrderId == pi.OrderId
                                       select p).FirstOrDefault(),
                              Product = (from p in _context.Products
                                         where p.ProductId == pi.ProductId
                                         select p).FirstOrDefault()
                          }).ToList();

            return detail;
        }
        catch (Exception)
        {
            return [];
        }
    }

}
