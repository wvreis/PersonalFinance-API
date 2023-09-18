using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Domain.Common;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; private set; }
}