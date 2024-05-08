using BE_restful.Areas.AdminManager.Models;
using BE_restful.Areas.AdminManager.Services;
using BE_restful.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("AdminManager/api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProducts _products;
    public ProductsController(IProducts products, ILogger<ProductsController> logger)
    {
        _products = products;
    }
    [HttpGet("GetPro")]
    public IActionResult GetPro()
    {
        var reuslt = _products.GetPro();
        if (reuslt == null || reuslt.Count == 0)
        {
            return NotFound();
        }
        return Ok(reuslt);
    }
    [HttpPost("AddProduct")]
    public IActionResult AddProduct(Product product)
    {
        bool result = _products.AddProduct(product);
        if(result)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }       
    }
    [HttpDelete("DeleteProduct")]
    public IActionResult DeleteProduct(string id)
    {
        bool result = _products.DeleteProduct(id);
        if (result)
        {
            return Ok(); 
        }
        else
        {
            return NotFound();
        }
    }
    [HttpPost("Update")]
    public IActionResult UpdateProduct(Product product)
    {
        bool result = _products.UpdateProduct(product);
        if (result)
        {
            return Ok();
        }
        else
        {
            return NotFound(); 
        }
    }
}
