using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly ISellerRepository _repository;
        public SellerController(ISellerRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sellers = await _repository.Get();
            return sellers.Any()
                    ? Ok(sellers)
                    : NotFound("Vendedor não encontrado!");
        }
    }
}