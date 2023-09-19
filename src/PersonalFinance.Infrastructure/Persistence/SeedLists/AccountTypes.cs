
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.Persistence.SeedLists;
public class AccountTypes {
    public static List<AccountType> GetAll()
    {
        return new() {
            new AccountType(description: "Carteira"),
            new AccountType(description: "Conta Corrente"),
            new AccountType(description: "Poupança"),
            new AccountType(description: "Outros")
        };
    }
}