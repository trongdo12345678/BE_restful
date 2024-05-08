using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Services;

public interface IDeliveryType
{
    DeliveryType? GetDeliveryTypeID(int paymentId);
    List<DeliveryType> GetAllDeliveryTypes();
    bool AddDeliveryType(DeliveryType deliveryType);
    bool DeleteDeliveryType(DeliveryType deliveryType);
    bool UpdateDeliveryType(DeliveryType deliveryType);
}
