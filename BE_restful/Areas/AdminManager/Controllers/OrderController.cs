using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("/AdminManager/api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private OrderService _orderService;
    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }
    //[Route("/Admin/api/depmgr/deps")]
    //[HttpPost]
    //public bool ConfirmOrder1(string productCode)
    //{
    //    var check = _orderService.ConfirmOrder(productCode);
    //    return check;
    //}
    //[Route("/Admin/api/depmgr/deps")]
    [HttpPost("UsersSend")]
    public bool UsersSend(Orders ords)
    {
        var checl = _orderService.UserSendOrder(ords);
        return checl;
    }
    [HttpPost("ConfirmOrder")] 
    public bool ConfirmOrder(string orderID, string productCode, int employeeid)
    {
        var checl = _orderService.ConfirmOrder(orderID, productCode, employeeid);
        return checl;
    }
    [HttpPost("ShipperOrder")]
    public bool ShipperOrder(string orderID, string productCode)
    {
        var checl = _orderService.ShippedOrder(orderID, productCode);
        return checl;
    }
    
    [HttpPost("AccomplishedOrder")]
    public bool AccomplishedOrder(string orderID, string productCode)
    {
        var checl = _orderService.AccomplishedOrder(orderID, productCode);
        return checl;
    }
    [HttpPost("AddFeedback")]
    public bool AddFeedback(string orderId, string feedbackMessage)
    {
        var checl = _orderService.AddFeedback(orderId, feedbackMessage);
        return checl;
    }
    [HttpGet("GetFeedback")]
    public IActionResult GetFeedback()
    {
        var check = _orderService.GetFeedback();
        return Ok(check);
    }
    [HttpGet("GetOrder")]
    public IActionResult GetOrder()
    {
        var check = _orderService.GetOrder();
        return Ok(check);
    }
    [HttpGet("GetOrderById/{id}")]
    public IActionResult GetOrderById(string id)
    {
        var order = _orderService.GetOrderid(id);
        if (order != null)
        {
            return Ok(order);
        }
        else
        {
            return NotFound();
        }
    }

}
