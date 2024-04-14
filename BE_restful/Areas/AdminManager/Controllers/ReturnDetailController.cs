using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[Area("admin")]
[ApiController]
public class ReturnDetailController : ControllerBase
{
    private ReturnDetailService _returndetailService;
    public ReturnDetailController(ReturnDetailService returndetailService)
    {
        _returndetailService = returndetailService;
    }
    //[Route("/Admin/api/depmgr/deps")]
    [HttpPost("ReturnToAdmin")]
    public bool ReturnToAdmin(ReturnDetail detail)
    {
        var check = _returndetailService.ReturnToAdmin(detail);
        return check;
    }
    [HttpPost("UpdateReturnForAdmin")]
    public bool UpdateReturnForAdmin(int returnId)
    {
        var check = _returndetailService.UpdateReturnForAdmin(returnId);
        return check;
    }
    [HttpPost("ShippedReturn")]
    public bool ShippedReturn(int returnId)
    {
        var check = _returndetailService.ShippedReturn(returnId);
        return check;
    }
    [HttpPost("AccomplishedReturn")]
    public bool AccomplishedReturn(int returnId)
    {
        var check = _returndetailService.AccomplishedReturn(returnId);
        return check;
    }
}
