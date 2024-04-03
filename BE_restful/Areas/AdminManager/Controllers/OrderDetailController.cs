using BE_restful.Areas.AdminManager.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[Area("Admin")]
[ApiController]
public class OrderDetailController : ControllerBase
{
    private OrderDetailService _orderDetailService;
    public OrderDetailController(OrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
    }
   // [Route("/Admin/api/depmgr/deps")]
    [HttpGet]
    public IActionResult GetOrderDetail()
    {
        var checkOrder = _orderDetailService.GetOrderDetail();
        if(checkOrder == null || checkOrder.Count == 0) 
        {
            return NotFound();
        }
        return Ok(checkOrder);
    }

}
