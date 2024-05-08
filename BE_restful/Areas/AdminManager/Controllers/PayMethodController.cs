using BE_restful.Areas.AdminManager.Services;
using BE_restful.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PayMethodController : ControllerBase
{
    private readonly IPayment _payment;
    public PayMethodController(IPayment payment)
    {
        _payment = payment;
    }
    [HttpGet]
    public IActionResult GetPaymentMethods()
    {
        // lay danh sach phuong thuc thanh toan trong csdl
        var paymentMethods = _payment.GetAllPaymentMethods();

        if (paymentMethods == null || paymentMethods.Count == 0)
        {
            return NotFound(); 
        }

        return Ok(paymentMethods); 
    }
    [HttpPost]
    public IActionResult AddPaymentMethod(PaymentMethod paymentMethod)
    {
        if (paymentMethod == null)
        {
            return BadRequest(); // khong co du lieu gui len tra ve 400
        }

        var success = _payment.AddPaymentMethod(paymentMethod);
        if (!success)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        return Ok();
    }

    [HttpPost("Update")]
    
    public IActionResult UpdatePaymentMethod( PaymentMethod paymentMethod)
    {
     
        bool result = _payment.UpdatePaymentMethod(paymentMethod);
        if(result)
        {
            return Ok();
        }
        return NotFound(); 
    }
    [HttpDelete]
    public IActionResult DeletePaymentMethod(int id)
    {
        var paymentMethod = _payment.GetPaymentMethodById(id);
        if(paymentMethod == null)
        {
            return NotFound();
        }
        bool result = _payment.DeletePaymentMethod(paymentMethod);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
}
