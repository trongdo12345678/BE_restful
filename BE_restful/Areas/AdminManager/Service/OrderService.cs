using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Service;

public interface OrderService
{
    public bool ConfirmOrder(string orderID, string productCode, int employeeid);
    public bool UserSendOrder(Orders ords);
    public bool findProductcode(string productcode);
    public bool ShippedOrder(string orderID, string productCode);
    public bool AccomplishedOrder(string orderID, string productCode);
    public bool AddFeedback(string orderId, string feedbackMessage);
    public List<Feedback> GetFeedback();
}
