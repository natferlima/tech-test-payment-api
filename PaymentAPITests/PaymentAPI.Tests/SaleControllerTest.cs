using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using tech_test_payment_api.Controllers;
using tech_test_payment_api.Models.DTO;
using tech_test_payment_api.Repository.Interfaces;

namespace PaymentAPI.Tests
{
    public class SaleControllerTest
    {
        private readonly ISaleRepository _repository = Substitute.For<ISaleRepository>();
        private readonly SaleController _controller;

        public SaleControllerTest()
        {
            _controller = new SaleController(_repository);
        }

        public async Task AddSale_ReturnsOK_WhenSaleCorrect()
        {
            ProductDTO newProduct = new ProductDTO {
                Name = "ProductName"
            };

            List<ProductDTO> newItems = new List<ProductDTO>()
            {
                newProduct
            };

            SellerDTO newSeller = new SellerDTO {
                CPF = "123.123.123-45",
                Name = "Teste",
                Email = "teste@email.com",
                PhoneNumber = "21966666666"
            };

            var newSale = new SaleDTO {
                Date = new DateTime(),
                Seller = newSeller,
                Items = newItems
            };


            _repository.SaveChanges().Returns(true);

            var response = await _controller.Post(newSale);

            var okResult = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}