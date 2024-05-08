using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Services;

public interface IPayment
{
    PaymentMethod? GetPaymentMethodById(int paymentId);
    List<PaymentMethod> GetAllPaymentMethods();
    bool AddPaymentMethod(PaymentMethod paymentMethod);
    bool DeletePaymentMethod(PaymentMethod paymentMethod);
    bool UpdatePaymentMethod(PaymentMethod paymentMethod);
}
