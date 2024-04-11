using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class CustomerDao : CustomerService
{
    private readonly ArtsContext _context;
    public CustomerDao(ArtsContext context)
    {
        _context = context;
    }
    //public List<Customer> GetAllCus()
    //{
    //    try
    //    {
    //        var res = _context.Customers.ToList();
    //        if(res != null)
    //        {
    //            return res;
    //        }
    //        return [];

    //    }catch (Exception)
    //    {
    //        return [];
    //    }
    //}
    public List<Customer> GetCus()
    {
        try
        {
            var customer = (from pi in _context.Customers
                            select new Customer
                            {
                                CustomerName = pi.CustomerName,
                                Address = pi.Address,
                                PhoneNumber = pi.PhoneNumber,
                                Email = pi.Email,
                                Username = pi.Username,
                                Password = pi.Password,
                                RoleId = pi.RoleId,
                                Role = (from p in _context.Roles
                                        where p.RoleId == pi.RoleId
                                        select p).FirstOrDefault()
                            }).ToList();

            return customer;
        }
        catch (Exception)
        {
            return [];
        }
    }
    public bool UpdateCus(Customer cus)
    {
        try
        {
            var p = _context.Customers.FirstOrDefault(p => p.CustomerId == cus.CustomerId);
            if (p != null)
            {
                p.CustomerName = cus.CustomerName;
                p.Address = cus.Address;
                p.PhoneNumber = cus.PhoneNumber;
                p.Email = cus.Email;
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
