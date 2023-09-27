using FluentValidation;

namespace PersonalFinance.Application.Accounts.Commands.AddAccount;

public class AddAccountCommandValidator : AbstractValidator<AddAccountCommand>
{
    public AddAccountCommandValidator()
    {
        RuleFor(v => v.Description)
            .MinimumLength(3)
            .MaximumLength(200)
            .WithMessage("Descrição deve ter entre 3 e 200 caracteres.");

        RuleFor(v => v.BankId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Um Banco deve ser informado.");

        RuleFor(v => v.AccountTypeId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Um Tipo de Conta deve ser informado.");
    }
}