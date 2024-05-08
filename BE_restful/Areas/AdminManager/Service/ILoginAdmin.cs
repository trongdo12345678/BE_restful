using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Services;

public interface ILoginAdmin
{
    int LoginAdmin(string userName, string password);
}
