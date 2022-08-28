using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
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
                    : NotFound("Nenhuma venda encontrada!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sale = await _repository.GetById(id);
            return sale != null
                    ? Ok(sale)
                    : NotFound("Venda não encontrada!");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Sale sale)
        {
            if(sale == null) return BadRequest("Dados inválidos");

            _repository.Add(sale);

            return await _repository.SaveChanges()
                    ? Ok("Venda adicionada com sucesso!")
                    : BadRequest("Erro ao salvar venda");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, string status)
        {
            if(id <= 0) return BadRequest("Venda não encontrada");

            var saleDatabase = await _repository.GetById(id);

            saleDatabase.Status = status;

            _repository.Update(saleDatabase);

            return await _repository.SaveChanges()
                    ? Ok("Venda atualizada com sucesso!")
                    : BadRequest("Erro ao atualizar venda");
        }
    }
}