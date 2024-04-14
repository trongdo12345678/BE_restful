using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class OrderDao : OrderService
{
    private readonly ArtsContext _context;
    public OrderDao(ArtsContext context)
    {
        _context = context;
    }
    //gửi tt xuống admin
    public bool UserSendOrder(Orders ords)
    {
        try
        {
            if (ords == null)
            {

                return false;
            }
            else
            {
                _context.Orders.Add(new Order()
                {
                    OrderId = DateTime.Now.Ticks.ToString().Substring(0, 8),
                    CustomerId = ords.CustomerId,
                    OrderDate = DateOnly.FromDateTime(DateTime.Now),
                    DeliveryTypeId = ords.DeliveryTypeId,
                    PaymentMethodId = ords.PaymentMethodId,
                    IsPaid = ords.IsPaid,
                    ProductId = ords.ProductId,
                    ProductCode =null,
                    EmployeeId = null,
                    Status = "Waiting for confirmation",
                    TotalPaid = ords.TotalPaid
                });

                return _context.SaveChanges() > 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in UserSendOrder: {ex.Message}");
            return false;
        }
    }
    //đang chờ xác nhận
    public bool ConfirmOrder(string orderID, string productCode, int employeeid)
    {
        try
        {
            var order = _context.Orders.SingleOrDefault(o => o.OrderId == orderID);
            if (order == null)
            {
                return false;
            }
            var deliveryTypeId = order.DeliveryTypeId;
            var cus = order.CustomerId;
            var pay = order.PaymentMethodId;
            var IsPa = order.IsPaid;
            var ProId = order.ProductId;
            var ToPaid = order.TotalPaid;

            var checkproductcode = findProductcode(productCode);
            if (checkproductcode)
            {
                _context.Orders.Remove(order);

                var newOrder = new Order
                {
                    OrderId = deliveryTypeId + productCode + order.OrderId,
                    ProductCode = productCode,
                    EmployeeId = employeeid,
                    OrderDate = DateOnly.FromDateTime(DateTime.Now),
                    DeliveryTypeId = deliveryTypeId,
                    CustomerId = cus,
                    PaymentMethodId = pay,
                    IsPaid = IsPa,
                    ProductId = ProId,
                    TotalPaid = ToPaid,
                };

                newOrder.Status = "Waiting for shipper";

                _context.Orders.Add(newOrder);
            }

            bool orderConfirmed = _context.SaveChanges() > 0;

            if (orderConfirmed)
            {
                UpdateProductCodeStatus(productCode, "sold");
            }

            return orderConfirmed; 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error confirming order: {ex.Message}");
            return false;
        }
    }
    // update trạng thái của productcode còn hàng or hết hàng
    private void UpdateProductCodeStatus(string productCode, string newStatus)
    {
        var productcd = _context.ProductCodes.FirstOrDefault(p => p.ProductCode1 == productCode);
        if (productcd != null)
        {
            productcd.Status = newStatus;
            _context.SaveChanges();
        }
    }
    //chuyển qua đang vận chuyển
    public bool ShippedOrder(string orderID, string productCode)
    {
        try
        {

            var order = _context.Orders.SingleOrDefault(o => o.OrderId == orderID);
            if (order == null)
            {
                return false;
            }
            var checkproductcode = findProductcode(productCode);
           
                order.OrderDate = DateOnly.FromDateTime(DateTime.Now);
                order.Status = "Shipped";

            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error confirming order: {ex.Message}");
            return false;
        }
    }
    // chuyển qua trạng thái đã hoàng thành
    public bool AccomplishedOrder(string orderId, string productCode)
    {
        try
        {
            var order = _context.Orders.SingleOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                return false;
            }
            order.OrderDate = DateOnly.FromDateTime(DateTime.Now);
            order.Status = "Accomplished";

            // Thêm phản hồi cho sản phẩm
            string feedbackMessage = "Thank you for your purchase!";
            AddFeedback(orderId, feedbackMessage);

            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error confirming order: {ex.Message}");
            return false;
        }
    }

    //kiểm tra xem product code có hợp lệ hay không
    public bool findProductcode(string productcode)
    {
        try
        {
            var check = _context.ProductCodes.SingleOrDefault(p => p.ProductCode1 == productcode);
            if (check == null)
            {
                return false;
            }
            else
            {
                if(check.Status == "ex")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
    //freeback cho sản phẩm
    public bool AddFeedback(string orderId, string feedbackMessage)
    {
        try
        {
            var order = _context.Orders.SingleOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                return false;
            }
            if (order.Status != "Accomplished")
            {
                Console.WriteLine("Cannot add feedback for orders that are not accomplished.");
                return false;
            }

            var feedback = new Feedback
            {
                OrderId = orderId,
                FeedbackDate = DateOnly.FromDateTime(DateTime.Now),
                FeedbackMessage = feedbackMessage
            };

            order.Feedbacks.Add(feedback);

            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding feedback: {ex.Message}");
            return false;
        }
    }
    public List<Feedback> GetFeedback()
    {
        try
        {
            var FreeB = (from p in _context.Feedbacks
                         select new Feedback
                           {
                             FeedbackId = p.FeedbackId,
                             FeedbackDate = p.FeedbackDate,
                             OrderId = p.OrderId,
                             FeedbackMessage = p.FeedbackMessage,
                             Order = (from pi in _context.Orders
                                        where pi.ProductId == pi.ProductId
                                          select pi).FirstOrDefault()
                           }).ToList();

            return FreeB;
        }
        catch (Exception)
        {
            return [];
        }
    }


}
