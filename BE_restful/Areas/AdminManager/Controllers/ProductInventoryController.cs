using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("/AdminManager/api/[controller]")]
[ApiController]
public class ProductInventoryController : ControllerBase
{
    private ProductInventoryService _productInventoryService;
    public ProductInventoryController(ProductInventoryService productInventoryService)
    {
        _productInventoryService = productInventoryService;
    }
    //[Route("/Admin/api/depmgr/deps")]
    [HttpPost("AddProductInventory")]
    public bool AddProductInventory(ProductInventory ProInven)
    {
        ProInven.DayInventory = DateOnly.FromDateTime(DateTime.Now);
        var check = _productInventoryService.InventoryProCode(ProInven);
        return check;
    }
    //[Route("/Admin/api/depmgr/deps")]
    [HttpGet("GetAllProductInventories")]
    public IActionResult GetAllProductInventories()
    {
        var inventories = _productInventoryService.GetAllProInven();
        return Ok(inventories); // Trả về danh sách các ProductInventory
    }
    [HttpGet("GetProIven")]
    public IActionResult GetProIven()
    {
        var Inven = _productInventoryService.GetProInven();

        if (Inven == null || Inven.Count == 0)
        {
            return NotFound(); // Trả về mã trạng thái 404 Not Found nếu không có dữ liệu
        }

        return Ok(Inven); // Trả về dữ liệu và mã trạng thái 200 OK
    }


}
