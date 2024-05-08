using BE_restful.Areas.AdminEmployee.Service;
using BE_restful.Areas.AdminManager.Services;
using BE_restful.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginEmployeeController : ControllerBase
{
    private readonly ILoginAdmin _loginAdmin;

    public LoginEmployeeController(ILoginAdmin loginAdmin)
    {
        _loginAdmin = loginAdmin;
    }
    [HttpPost]
    [Route("login")]
    public IActionResult LoginAdmin(string username, string password)
    {
        int isAuthenticated = _loginAdmin.LoginAdmin(username, password);
        if (isAuthenticated == 1)
        {
            return Ok("Manager"); //tra ve trang manager
        }
        else if (isAuthenticated == 2)
        {
            return Ok("Employee"); // tra ve trang employee
        }
        else
        {
            return NotFound("User not found or password mismatch."); // sai mk tk
        }
    }


}
