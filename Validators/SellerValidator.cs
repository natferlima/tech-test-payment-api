using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Validators
{
    public class SellerValidator : AbstractValidator<Seller>
    {
        public SellerValidator() 
        {
            RuleFor(seller => seller.CPF)
                .NotNull()
                .WithMessage("O campo é obrigatório!");
            RuleFor(sale => sale.CPF)
                .NotEmpty()
                .WithMessage("O campo não pode ser vazio!");
        }
    }
}