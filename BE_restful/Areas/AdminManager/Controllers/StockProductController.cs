using BE_restful.Areas.AdminManager.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[Area("Admin")]
[ApiController]
public class StockProductController : ControllerBase
{
    private StockProductService _stockProductService;
    public StockProductController(StockProductService stockProductService)
    {
        _stockProductService = stockProductService;
    }
    [HttpGet]
    public IActionResult GetStockPro()
    {
        var checkstock = _stockProductService.GetOrderDetail();
        if(checkstock == null || checkstock.Count == 0)
        {
            return NotFound();
        }
        return Ok(checkstock);
    }
}
