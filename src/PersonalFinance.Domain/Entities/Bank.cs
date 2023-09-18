using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Domain.Entities;

public class Bank : BaseEntity
{    
    public int Number { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public List<Account> Accounts { get; private set; } = new();

    public Bank(
        string name,
        int number,
        List<Account> accounts)
    {
        Name = name;
        Number = number;
        Accounts = accounts;
    }

    public Bank()
    {
    }
}