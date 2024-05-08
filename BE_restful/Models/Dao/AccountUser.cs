using BE_restful.Models;
using BE_restful.Services;
using Microsoft.EntityFrameworkCore;

namespace BE_restful.Models.Dao;

public class AccountUser : IAccountUser
{
    public readonly ArtsContext _context;
    public AccountUser(ArtsContext context)
    {
        _context = context;
    }

    public bool LoginUser(string username, string password)
    {
        var customer = _context.Customers.Include(m => m.Role).FirstOrDefault(m => m.Username == username);
        if (customer != null && customer.RoleId == 3) // dang nhap khi roleID = 3(User)
        {
            return BCrypt.Net.BCrypt.Verify(password, customer.Password);
        }
        return false;
    }

    public bool Register(Customer customer)
    {

        var existingAdmin = _context.Employees.FirstOrDefault(m => m.Username == customer.Username);
        if (existingAdmin != null)
        {
            return false;
        }

        customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);

        var userRole = _context.Roles.FirstOrDefault(r => r.RoleId == 3);
        if (userRole != null)
        {
            customer.RoleId = userRole.RoleId;
        }
        else
        {
            var newUserRole = new Role { RoleId = 3, RoleName = "User" };
            _context.Roles.Add(newUserRole);
            _context.SaveChanges();
            customer.RoleId = newUserRole.RoleId;
        }

        _context.Customers.Add(customer);
        _context.SaveChanges();

        return true;

    }
}
