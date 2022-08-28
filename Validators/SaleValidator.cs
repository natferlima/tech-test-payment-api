using FluentValidation;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Validators
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator() 
        {
            RuleFor(sale => sale.Items)
                .NotNull()
                .WithMessage("Campo obrigatório!");
        }
    }
}