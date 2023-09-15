using FluentValidation;

namespace PersonalFinance.Application.Accounts.Commands;

public class AddAccountCommandValidator : AbstractValidator<AddAccountCommand>
{
    public AddAccountCommandValidator()
    {
        RuleFor(v => v.Description)
            .MinimumLength(3)
            .MaximumLength(200)
            .WithMessage("Descrição deve ter entre 3 e 200 caracteres.");
    }
}