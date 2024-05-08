using BE_restful.Models;

namespace BE_restful.Services;

public interface IAccountUser
{
    bool Register(Customer customer);
    bool LoginUser(string username, string password);
}
