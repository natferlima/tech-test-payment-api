using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
using tech_test_payment_api.Models.DTO;
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
        public async Task<IActionResult> Post(SaleDTO sale)
        {
            if(sale == null) return BadRequest("Dados inválidos");

            List<Product> newItems = new List<Product>()
            {
            };

            foreach (var item in sale.Items!)
            {   
                Product newProduct = new Product {
                    Id = 0,
                    Name = item.Name
                };
                newItems.Add(newProduct);
            }

            Seller newSeller = new Seller {
                Id = 0,
                CPF = sale.Seller!.CPF,
                Name = sale.Seller.Name,
                Email = sale.Seller.Email,
                PhoneNumber = sale.Seller.PhoneNumber
            };

            var newSale = new Sale {
                Id = 0,
                Date = sale.Date,
                Seller = newSeller,
                Items = newItems,
                Status = "Aguardando pagamento"
            };

            _repository.Add(newSale);

            return await _repository.SaveChanges()
                    ? Ok("Venda adicionada com sucesso!")
                    : BadRequest("Erro ao salvar venda");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, string status)
        {
            List<string> listStatus = new List<string>()
            {
                "Pagamento aprovado",
                "Enviado para transportadora",
                "Entregue",
                "Cancelada"
            };

            if(!listStatus.Contains(status)) return BadRequest("Status Permitidos: Pagamento aprovado, Enviado para transportadora, Entregue, Cancelada");

            if(id <= 0) return BadRequest("Venda não encontrada");

            var saleDatabase = await _repository.GetById(id);

            if(saleDatabase.Status == "Aguardando pagamento") {
                if(status != listStatus[0] && status != listStatus[3]) return BadRequest("Atualizações permitidas: Pagamento aprovado ou Cancelada");
            }
            if(saleDatabase.Status == listStatus[0]) {
                if(status != listStatus[1] && status != listStatus[3]) return BadRequest("Atualizações permitidas: Enviado para transportadora ou Cancelada");
            }
            if(saleDatabase.Status == listStatus[1]) {
                if(status != listStatus[2]) return BadRequest("Atualizações permitidas: Entregue");
            }

            saleDatabase.Status = status;

            _repository.Update(saleDatabase);

            return await _repository.SaveChanges()
                    ? Ok("Venda atualizada com sucesso!")
                    : BadRequest("Erro ao atualizar venda");
        }
    }
}