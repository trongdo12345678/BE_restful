using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Services;

public interface IUpdatePassword
{
    bool UpdatePasswords(string username, string oldPassword, string newPassword);
}
