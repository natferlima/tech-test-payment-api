using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
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
                    : NotFound("Nenhum vendedor encontrado!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var seller = await _repository.GetById(id);
            return seller != null
                    ? Ok(seller)
                    : NotFound("Vendedor não encontrado!");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Seller seller)
        {
            if(seller == null) return BadRequest("Dados inválidos");

            _repository.Add(seller);

            return await _repository.SaveChanges()
                    ? Ok("Vendedor cadastrado com sucesso!")
                    : BadRequest("Erro ao cadastrar vendedor");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Vendedor inválido");

            var sellerDatabase = await _repository.GetById(id);

            if(sellerDatabase == null) return NotFound("Vendedor não encontrado");

            _repository.Delete(sellerDatabase);

            return await _repository.SaveChanges()
                    ? Ok("Vendedor deletado com sucesso!")
                    : BadRequest("Erro ao deletar vendedor");
        }
    }
}