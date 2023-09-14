using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PersonalFinance.Application.Accounts.Commands;

public class AddAccountCommand : IRequest<int>
{    
    [MaxLength(200, ErrorMessage = "A descrição não pode conter mais de 200 caracteres.")]
    [MinLength(3, ErrorMessage = "A descrição deve ter mais de 3 caracteres.")]
    public string Description { get; set; } = string.Empty;

    public double OpeningBalance { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Um Banco deve ser selecionado.")]
    public int BankId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "O Tipo de Conta deve ser informado.")]
    public int AccountTypeId { get; set; }
}