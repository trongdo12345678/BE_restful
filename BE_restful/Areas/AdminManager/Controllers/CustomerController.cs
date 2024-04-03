using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using Microsoft.AspNetCore.Mvc;


namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[Area("Admin")]
[ApiController]
public class CustomerController : ControllerBase
{
    private CustomerService _customerService;
    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }
    //[Route("/Admin/api/depmgr/deps")]
    [HttpGet]
    public IActionResult GetCus()
    {
        var customer = _customerService.GetCus();
        if(customer == null || customer.Count == 0)
        {
            return NotFound();
        }
        return Ok(customer);
    }
    //[Route("/Admin/api/depmgr/deps")]
    [HttpPost]
    public bool UpdateCus(Customer cus)
    {
        var checkUpdateCus = _customerService.UpdateCus(cus);
        return checkUpdateCus;
    }
}
