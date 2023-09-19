using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.Persistence.SeedLists;
public class Banks
{
    public static List<Bank> GetAll()
    {
        return new()
        {
            new Bank (name: "Banco do Brasil", number: 1),
            new Bank (name: "Banco Bradesco", number: 237),
            new Bank (name: "Caixa Econômica Federal", number: 104),
            new Bank (name: "Itaú Unibanco", number: 341),
            new Bank (name: "Santander", number: 33),
            new Bank (name: "Banco Safra", number: 422),
            new Bank (name: "Banco BTG Pactual", number: 208),
            new Bank (name: "Banco Inter", number: 77),
            new Bank (name: "Nubank", number: 260),
            new Bank (name: "Banrisul", number: 041),
            new Bank (name: "Banco Votorantim", number: 655),
            new Bank (name: "Banco do Nordeste", number: 004),
            new Bank (name: "Banestes", number: 021),
            new Bank (name: "Banco Daycoval", number: 707),
            new Bank (name: "Banco Alfa", number: 25),
            new Bank (name: "Banco Original", number: 212),
            new Bank (name: "Banco Pine", number: 643),
            new Bank (name: "Banco Sofisa", number: 637),
        };
    }
}
