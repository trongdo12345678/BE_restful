using BE_restful.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_restful.Areas.AdminManager.Service;

public interface OrderDetailService
{
    public List<OrderDetail> GetOrderDetail();
}
