using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[Area("admin")]
[ApiController]
public class FAQsController : ControllerBase
{
    private FAQsService _FAQsService;
    public FAQsController(FAQsService FAQsService)
    {
        _FAQsService = FAQsService;
    }
    [HttpGet("GetFA")]
    public IActionResult GetFA()
    {
        var check = _FAQsService.GetFAQ();
        return Ok(check);
    }
    [HttpPost("AddFa")]
    public bool AddFa(Faq fa)
    {
        var checkkk = _FAQsService.AddQuesionFAQ(fa);
        return checkkk;
    }
}
