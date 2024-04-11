using BE_restful.Areas.AdminManager.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductCodeController : ControllerBase
{
    private ProductCodeService _productCodeService;
    public ProductCodeController(ProductCodeService productCodeService)
    {
        _productCodeService = productCodeService;
    }
    [HttpGet]
    public IActionResult GetProCode()
    {
        var check = _productCodeService.GetProCode();
        return Ok(check);
    }
}
