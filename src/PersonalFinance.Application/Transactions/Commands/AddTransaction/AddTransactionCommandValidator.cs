using FluentValidation;

namespace PersonalFinance.Application.Transactions.Commands.AddTransaction;

public class AddTransactionCommandValidator : AbstractValidator<AddTransactionCommand>
{
    public AddTransactionCommandValidator()
    {
        RuleFor(v => v.Description)
            .MinimumLength(3)
            .MaximumLength(200)
            .WithMessage("Descrição deve ter entre 3 e 200 caracteres.");

        RuleFor(v => v.AccountId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Uma Conta deve ser informado.");

        RuleFor(v => v.TransactionTypeId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Um Tipo de Movimentação deve ser informado.");

        RuleFor(v => v.Status)
            .IsInEnum()
            .WithMessage("Um valor válido para Status deve ser informado.");
        
        RuleFor(v => v.Nature)
            .IsInEnum()
            .WithMessage("Um valor válido para Natureza deve ser informado.");

        RuleFor(v => v.Amount)
            .GreaterThan(.01)
            .WithMessage("Um Valor deve ser informado");
    }
}