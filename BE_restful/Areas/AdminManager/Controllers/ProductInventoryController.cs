using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_restful.Areas.Admin.Controllers;
[Route("api/[controller]")]
[Area("Admin")]
[ApiController]
public class ProductInventoryController : ControllerBase
{
    private ProductInventoryService _productInventoryService;
    public ProductInventoryController(ProductInventoryService productInventoryService)
    {
        _productInventoryService = productInventoryService;
    }
    //[Route("/Admin/api/depmgr/deps")]
    [HttpPost]
    public bool AddProInven(ProductInventory ProInven)
    {

            // Thêm yếu tố ProductInventory mới vào cơ sở dữ liệu
            var check = _productInventoryService.AddProInven(ProInven);

            // Lấy dữ liệu ProductInventory sau khi thêm mới để đảm bảo tính nhất quán
            //var updatedInventory = _productInventoryService.GetPro(); ViewBag lay gia tri product ra

            // Kiểm tra xem thêm mới có thành công không
            return check;
    }
    [HttpGet]
    public IActionResult GetProCate()
    {
        var Inven = _productInventoryService.GetProInven();

        if (Inven == null || Inven.Count == 0)
        {
            return NotFound(); // Trả về mã trạng thái 404 Not Found nếu không có dữ liệu
        }

        return Ok(Inven); // Trả về dữ liệu và mã trạng thái 200 OK
    }


}
