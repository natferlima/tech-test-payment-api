using FluentValidation;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Validators
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator() 
        {
            RuleFor(sale => sale)
                .NotNull()
                .WithMessage("O preenchimento dos campos é obrigatório!");

            When(sale => sale != null, () => {
                RuleFor(sale => sale.Items)
                    .NotNull()
                    .WithMessage("O campo é obrigatório!");
                RuleFor(sale => sale.Items)
                    .NotEmpty()
                    .WithMessage("O campo não pode ser vazio!");
                RuleForEach(sale => sale.Items)
                    .NotEmpty()
                    .WithMessage("O campo não pode ser vazio!");
                
                When(sale => sale.Items != null, () => {
                    RuleFor(sale => sale.Items)
                        .Must(list => list.Count <= 1)
                        .WithMessage("A lista deve conter pelo menos 1 item.");
                    RuleForEach(sale => sale.Items).ChildRules(items => 
                    {
                        items.RuleFor(x => x.Name)
                            .NotNull()
                            .WithMessage("O campo é obrigatório!");
                        items.RuleFor(x => x.Name)
                            .NotEmpty()
                            .WithMessage("O campo não pode ser vazio.");
                        items.RuleFor(x => x.Name)
                            .MinimumLength(3)
                            .WithMessage("O campo deve ter pelo menos 3 caracteres.");
                    });
                });

                RuleFor(sale => sale.Date)
                    .NotNull()
                    .WithMessage("O campo é obrigatório!");
                RuleFor(sale => sale.Date)
                    .NotEmpty()
                    .WithMessage("O campo não pode ser vazio.");
                RuleFor(sale => sale.Status)
                    .NotNull()
                    .WithMessage("O campo é obrigatório!");
                RuleFor(sale => sale.Status)
                    .NotEmpty()
                    .WithMessage("O campo não pode ser vazio.");
                RuleFor(sale => sale.Seller)
                    .NotNull()
                    .WithMessage("O campo é obrigatório!");
                RuleFor(sale => sale.Seller)
                    .NotEmpty()
                    .WithMessage("O campo é obrigatório!");

                When(sale => sale.Seller != null, () => {
                    RuleFor(sale => sale.Seller.CPF)
                        .NotNull()
                        .WithMessage("O campo é obrigatório!");
                    RuleFor(sale => sale.Seller.CPF)
                        .NotEmpty()
                        .WithMessage("O campo não pode ser vazio!");
                    RuleFor(sale => sale.Seller!.CPF)
                        .Matches("[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}")
                        .WithMessage("O campo é invalido! Formato correto para CPF: 123.123.123-12");
                    RuleFor(sale => sale.Seller.Name)
                        .NotNull()
                        .WithMessage("O campo é obrigatório!");
                    RuleFor(sale => sale.Seller.Name)
                        .NotEmpty()
                        .WithMessage("O campo não pode ser vazio.");
                    RuleFor(sale => sale.Seller.Name)
                        .MinimumLength(3)
                        .WithMessage("O campo deve ter pelo menos 3 caracteres.");
                    RuleFor(sale => sale.Seller.Email)
                        .NotNull()
                        .WithMessage("O campo é obrigatório!");
                    RuleFor(sale => sale.Seller.Name)
                        .NotEmpty()
                        .WithMessage("O campo não pode ser vazio.");
                    RuleFor(sale => sale.Seller.Email)
                        .EmailAddress()
                        .WithMessage("O campo é inválido.");
                    RuleFor(sale => sale.Seller.PhoneNumber)
                        .NotNull()
                        .WithMessage("O campo é obrigatório!");
                    RuleFor(sale => sale.Seller.PhoneNumber)
                        .NotEmpty()
                        .WithMessage("O campo não pode ser vazio.");
                    RuleFor(sale => sale.Seller!.PhoneNumber)
                        .Matches("[0-9]{11}")
                        .WithMessage("O campo deve ter 11 números");
                });   
            });  
        }
    }
}