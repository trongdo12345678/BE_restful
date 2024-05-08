using BE_restful.Models;
using BE_restful.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_restful.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountUserController : ControllerBase
{
    private IAccountUser _accountUser;
    public AccountUserController(IAccountUser accountUser)
    {
        _accountUser = accountUser;
    }

    [HttpPost]
    [Route("Register")]
    public IActionResult RegisterUser(string Email, string username, string password)
    {
        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return BadRequest("All fields are required.");
        }

        Customer customer = new Customer
        {
            Email = Email,
            Username = username,
            Password = password
        };


        bool isRegistered = _accountUser.Register(customer);

        if (isRegistered)
        {
            return Ok("Registration successful.");
        }
        else
        {
            return BadRequest("Username already exists.");
        }
    }
    [HttpPost]
    [Route("Login")]
    public IActionResult LoginUser(string username, string password)
    {
        bool isAuthenticated = _accountUser.LoginUser(username, password);
        if (isAuthenticated)
        {
            return Ok("Login successful");
        }
        else
        {
            return Unauthorized("Invalid username or password.");
        }
    }
}
