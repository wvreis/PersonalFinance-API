
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.Persistence.SeedLists;
public class TransactionTypeGroups {
    public static List<TransactionTypeGroup> GetAll()
    {
        return new() {
            new TransactionTypeGroup(id: 1, description: "Habitação" ),
            new TransactionTypeGroup(id: 2, description: "Alimentação" ),
            new TransactionTypeGroup(id: 3, description: "Transporte" ),
            new TransactionTypeGroup(id: 4, description: "Saúde" ),
            new TransactionTypeGroup(id: 5, description: "Educação" ),
            new TransactionTypeGroup(id: 6, description: "Lazer" ),
            new TransactionTypeGroup(id: 7, description: "Vestuário" ),
            new TransactionTypeGroup(id: 8, description: "Finanças" ),
            new TransactionTypeGroup(id: 9, description: "Impostos" ),
            new TransactionTypeGroup(id: 10, description: "Doações e Caridade" ),
            new TransactionTypeGroup(id: 11, description: "Investimentos" ),
            new TransactionTypeGroup(id: 12, description: "Seguro" ),
            new TransactionTypeGroup(id: 13, description: "Receitas")
        };
    }
}