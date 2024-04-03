using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using Microsoft.AspNetCore.Mvc;


namespace BE_restful.Areas.Admin.Controllers;
[ApiController]
[Route("api/[controller]")]
[Area("Admin")]
public class ProductCategoryController : ControllerBase
{
    private ProductCategoryService _productCategoriesService;
    public ProductCategoryController(ProductCategoryService productCategoriesService)
    {
        _productCategoriesService = productCategoriesService;
    }
    [HttpGet]
    public IActionResult GetProCate()
    {
        var categories = _productCategoriesService.GetProCate();

        if (categories == null || categories.Count == 0)
        {
            return NotFound(); // Trả về mã trạng thái 404 Not Found nếu không có dữ liệu
        }

        return Ok(categories); // Trả về dữ liệu và mã trạng thái 200 OK
    }
   // [Route("/Admin/api/depmgr/deps")]
    [HttpPost("addprocate")]
    public bool addprocate(ProductCategory proCate)
    {
        var procheck = _productCategoriesService.AddProCate(proCate);
        return procheck;
    }

    //[Route("/Admin/api/depmgr/deps/{id}")]
    [HttpDelete]
    public IActionResult DeleteCategory(int id)
    {
        var success = _productCategoriesService.DeleteCate(id);

        if (success)
        {
            return Ok("Category deleted successfully.");
        }
        else
        {
            return NotFound("Category not found.");
        }
    }


    [HttpPost("updateCate")]
    public bool updateCate(ProductCategory proCate)
    {
        var procheck = _productCategoriesService.UpdateCate(proCate);
        return procheck;
    }

}
