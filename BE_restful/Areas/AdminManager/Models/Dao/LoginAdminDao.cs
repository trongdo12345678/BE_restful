using BE_restful.Areas.AdminEmployee.Service;
using BE_restful.Areas.AdminManager.Services;
using BE_restful.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class LoginAdminDao : ILoginAdmin
{
    public readonly ArtsContext _context;
    public LoginAdminDao(ArtsContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
    }
    public int LoginAdmin(string userName, string password)
    {
        var employee = _context.Employees.Include(m => m.Role).FirstOrDefault(m => m.Username == userName);

        if (employee != null)
        {
            if (employee.RoleId == 1)
            {
                return BCrypt.Net.BCrypt.Verify(password, employee.Password) ? 1 : 0; // tra ve 1 neu la manager, nguoc lai tra ve 0, manager tu them khong can so sanh voi mat khau ma hoa
            }
            else if (employee.RoleId == 2)
            {
                return BCrypt.Net.BCrypt.Verify(password, employee.Password) ? 2 : 0; // tra ve 2 neu la employee, nguoc lai tra ve 0
            }
        }

        return 0; // truong hop khong tim thay, hoac roleId khong hop le
    }
}
