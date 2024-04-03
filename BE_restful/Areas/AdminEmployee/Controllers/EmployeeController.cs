using BE_restful.Areas.AdminEmployee.Service;
using BE_restful.Models;
using Microsoft.AspNetCore.Mvc;
using Konscious.Security.Cryptography;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_restful.Areas.AdminEmployee.Controllers;
[Route("api/[controller]")]
[Area("Admin")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private EmployeeService _employeeService;
    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    //[Route("/Admin/api/depmgr/deps")]
    [HttpGet]
    public IActionResult GetEmloy()
    {
        var check = _employeeService.GetEmloy();
        if(check == null || check.Count == 0) { return NotFound();  }
        return Ok(check);
    }
    
    [HttpPost("AddEmloy")]
    public bool AddEmloy(Employee employee)
    {
        employee.Password = BCrypt.Net.BCrypt.HashPassword(employee.Password);
        var checkAdd = _employeeService.AddEmloy(employee);
        return checkAdd;
    }
    //[Route("/Admin/api/depmgr/deps/{id}")]
    [HttpDelete]
    public IActionResult DeleteEmloy(int id)
    {
        var success = _employeeService.DeleteEmloy(id);
        if (success)
        {
            return Ok("delete success");
        }else
        {
            return NotFound("delete not.");
        }
    }
    
    [HttpPost("UpdateEmloy")]
    public bool UpdateEmloy(Employee employee)
    {
        var checkupdate = _employeeService.UpdateEmloy(employee);
        return checkupdate;
    }

}
