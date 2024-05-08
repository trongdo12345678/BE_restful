using BE_restful.Areas.AdminManager.Services;
using BE_restful.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DeliveryTypeController : ControllerBase
{
    private readonly IDeliveryType _deliveryType;

    public DeliveryTypeController(IDeliveryType deliveryType)
    {
        _deliveryType = deliveryType;
    }

    [HttpGet]
    public IActionResult GetDeliveryType()
    {
        var deliveryType = _deliveryType.GetAllDeliveryTypes();

        if(deliveryType == null) 
        {
            return NotFound();
        }
        return Ok(deliveryType);
    }

    [HttpPost("Add")]
    public IActionResult AddDeliveryType(DeliveryType deliveryType)
    {
        var sucess = _deliveryType.AddDeliveryType(deliveryType);
        if (!sucess)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        return Ok();
    }
    [HttpDelete("Delete")]
    public IActionResult DeleteDeliveryType(int id)
    {
        var deliveryType = _deliveryType.GetDeliveryTypeID(id);
        if (deliveryType == null)
        {
            return NotFound();
        }
        var result = _deliveryType.DeleteDeliveryType(deliveryType);
        if (result)
        {
            return Ok(result);
        }
        return NotFound();
    }

    [HttpPost("Update")]
    public IActionResult UpdateDeliveryType(DeliveryType deliveryType)
    {
        var result = _deliveryType.UpdateDeliveryType(deliveryType);
        if (result)
        {
            return Ok();
        }
        return NotFound();
    }
}
