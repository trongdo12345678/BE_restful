﻿using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[Area("admin")]
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
    [HttpPost]
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
}