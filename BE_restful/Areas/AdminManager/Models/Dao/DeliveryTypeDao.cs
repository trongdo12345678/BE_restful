using BE_restful.Areas.AdminManager.Services;
using BE_restful.Models;
using System.Runtime.Intrinsics.Arm;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class DeliveryTypeDao : IDeliveryType
{
    public readonly ArtsContext _context;
    public DeliveryTypeDao(ArtsContext context)
    {
        _context = context;
    }

    public bool AddDeliveryType(DeliveryType deliveryType)
    {
        try
        {
            _context.DeliveryTypes.Add(deliveryType);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    public bool DeleteDeliveryType(DeliveryType deliveryType)
    {
        try
        {
            _context.DeliveryTypes.Remove(deliveryType);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    public List<DeliveryType> GetAllDeliveryTypes()
    {
        var getAllDeliType = (from d in _context.DeliveryTypes
                              select new DeliveryType
                              {
                                  DeliveryTypeId = d.DeliveryTypeId,
                                  TypeName = d.TypeName,
                              }).ToList();
        return getAllDeliType;
    }

    public DeliveryType? GetDeliveryTypeID(int paymentId)
    {
        var deliveryType = (from d in _context.DeliveryTypes
                            where d.DeliveryTypeId == paymentId
                            select new DeliveryType
                            {
                                DeliveryTypeId = d.DeliveryTypeId,
                                TypeName = d.TypeName,
                            }).FirstOrDefault();
        return deliveryType;
    }

    public bool UpdateDeliveryType(DeliveryType deliveryType)
    {
        var existingDeli = _context.DeliveryTypes.FirstOrDefault(e => e.DeliveryTypeId == deliveryType.DeliveryTypeId);
        if (existingDeli != null)
        {
            existingDeli.TypeName = deliveryType.TypeName;
            return _context.SaveChanges() > 0;
        }
        return true;
    }
}
