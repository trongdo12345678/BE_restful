using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class ReturnDetailDao : ReturnDetailService
{
    private readonly ArtsContext _context;
    public ReturnDetailDao(ArtsContext context)
    {
        _context = context;
    }
    //gửi xác nhận về cho admin
    public bool ReturnToAdmin(ReturnDetail detail)
    {
        try
        {
            if (detail == null)
            {
                return false;
            }else
            {
                _context.ReturnDetails.Add(new ReturnDetail
                {
                    OrderId = detail.OrderId,
                    Status = "Return confirmation",
                    ReturnDate = DateOnly.FromDateTime(DateTime.Now),
                    Reason = detail.Reason,
                    EmployeeId = detail.EmployeeId,
                });
                return _context.SaveChanges() > 0;
            }
           
        }catch (Exception ex)
        {
            Console.WriteLine($"Error in UserSendOrder: {ex.Message}");
            return false;
        }
    }
    //xác nhận trả hàng về cho admin
    public bool UpdateReturnForAdmin(int returnId)
    {
        try
        {
            var returnDetail = _context.ReturnDetails.FirstOrDefault(rd => rd.ReturnId == returnId);
            if (returnDetail == null)
            {
                return false;
            }

            returnDetail.Status = "Returned";

            UpdateProductCodeStatus(returnDetail.OrderId, "ex");

            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating return for admin: {ex.Message}");
            return false;
        }
    }
    //thay đổi trạng thái đơn hàng
    private void UpdateProductCodeStatus(string orderId, string newStatus)
    {
        var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order != null)
        {
            var productCode = order.ProductCode;

            var product = _context.ProductCodes.FirstOrDefault(p => p.ProductCode1 == productCode);
            if (product != null)
            {
                product.Status = newStatus;
            }
        }
    }
    //shiper nhận hàng và xác nhận đang vận chuyển
    public bool ShippedReturn(int returnId)
    {
        try
        {
            var returnDetail = _context.ReturnDetails.FirstOrDefault(rd => rd.ReturnId == returnId);
            if (returnDetail == null)
            {
                return false;
            }

            returnDetail.Status = "Shipped";

           
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating return for admin: {ex.Message}");
            return false;
        }
    }
    public bool AccomplishedReturn(int returnId)
    {
        try
        {
            var returnDetail = _context.ReturnDetails.FirstOrDefault(rd => rd.ReturnId == returnId);
            if (returnDetail == null)
            {
                return false;
            }

            returnDetail.Status = "Accomplished Return";


            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating return for admin: {ex.Message}");
            return false;
        }
    }

}

