using BE_restful.Areas.AdminManager.Services;
using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class UpdatePasswordDao : IUpdatePassword
{
    public ArtsContext _context;
    public UpdatePasswordDao(ArtsContext context)
    {
        _context = context;
    }

    public bool UpdatePasswords(string username, string oldPassword, string newPassword)
    {
        var user = _context.Customers.FirstOrDefault(cus => cus.Username == username);
        if (user != null)
        {

            if (BCrypt.Net.BCrypt.Verify(oldPassword, user.Password))
            {

                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                _context.SaveChanges();
                return true;
            }
            else
            {

                return false;
            }
        }
        return false;
    }

}
