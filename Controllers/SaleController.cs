using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _repository;
        public SaleController(ISaleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sales = await _repository.Get();
            return sales.Any()
                    ? Ok(sales)
                    : NotFound("Venda não encontrado!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sale = await _repository.GetById(id);
            return sale != null
                    ? Ok(sale)
                    : NotFound("Venda não encontrado!");
        }
    }
}