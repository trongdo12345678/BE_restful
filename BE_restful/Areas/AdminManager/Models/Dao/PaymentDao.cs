using BE_restful.Areas.AdminManager.Services;
using BE_restful.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class PaymentDao : IPayment
{
    public readonly ArtsContext _context;
    public PaymentDao(ArtsContext context)
    {
        _context = context;
    }
    // them phuong thuc thanh toan
    public bool AddPaymentMethod(PaymentMethod paymentMethod)
    {
        try
        {
            _context.PaymentMethods.Add(paymentMethod);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
    // xoa phuong thuc
    public bool DeletePaymentMethod(PaymentMethod paymentMethod)
    {
        try
        {
            _context.PaymentMethods.Remove(paymentMethod);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    //lay phuong thuc thanh toan trong csdl
    public List<PaymentMethod> GetAllPaymentMethods()
    {
        var getAllPay = (from gAP in _context.PaymentMethods
                         select new PaymentMethod
                         {
                             PaymentMethodId = gAP.PaymentMethodId,
                             PaymentMethodName = gAP.PaymentMethodName,
                         }).ToList();
        return getAllPay;
    }

    public PaymentMethod? GetPaymentMethodById(int paymentId)
    {
        var paymentMethod = (from pay in _context.PaymentMethods
                             where pay.PaymentMethodId == paymentId
                             select new PaymentMethod
                             {
                                 PaymentMethodId = pay.PaymentMethodId,
                                 PaymentMethodName = pay.PaymentMethodName
                             }).FirstOrDefault();
        return paymentMethod;

    }
    // cap nhat phuong thuc thanh toan
    public bool UpdatePaymentMethod(PaymentMethod paymentMethod)
    {
        try
        {
            var existingPayment = _context.PaymentMethods.FirstOrDefault(p => p.PaymentMethodId == paymentMethod.PaymentMethodId);
            if (existingPayment != null)
            {
                existingPayment.PaymentMethodName = paymentMethod.PaymentMethodName;

                return _context.SaveChanges() > 0;
            }
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
}
