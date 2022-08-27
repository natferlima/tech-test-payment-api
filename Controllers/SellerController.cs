using Microsoft.AspNetCore.Mvc;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Tudo certo!!");
        }
    }
}