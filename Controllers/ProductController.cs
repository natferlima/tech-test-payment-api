using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repository.Get();
            return products.Any()
                    ? Ok(products)
                    : NotFound("Nenhum produto encontrado!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.GetById(id);
            return product != null
                    ? Ok(product)
                    : NotFound("Produto não encontrado!");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            if(product == null) return BadRequest("Dados inválidos");

            _repository.Add(product);

            return await _repository.SaveChanges()
                    ? Ok("Produto cadastrado com sucesso!")
                    : BadRequest("Erro ao cadastrar produto");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Produto inválido!");

            var productDatabase = await _repository.GetById(id);

            if(productDatabase == null) return NotFound("Produto não encontrado!");

            _repository.Delete(productDatabase);

            return await _repository.SaveChanges()
                    ? Ok("Produto deletado com sucesso!")
                    : BadRequest("Erro ao deletar produto!");
        }
    }
}