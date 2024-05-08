using BE_restful.Areas.AdminManager.Services;
using BE_restful.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UpdatePasswordController : ControllerBase
{
    private readonly IUpdatePassword _updatePassword;

    public UpdatePasswordController(IUpdatePassword updatePassword)
    {
        _updatePassword = updatePassword;
    }

    [HttpPost]
    public IActionResult UpdatePassword(string username, string oldPassword, string newPassword)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
        {
            return BadRequest("Invalid request data.");
        }

        if (_updatePassword.UpdatePasswords(username, oldPassword, newPassword))
        {
            return Ok("Password updated successfully.");
        }
        else
        {
            return NotFound("User not found or password mismatch.");
        }
    }

}
