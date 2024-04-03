using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Service;

public interface CustomerService
{
    public List<Customer> GetCus();
    public bool UpdateCus(Customer cus);
}
