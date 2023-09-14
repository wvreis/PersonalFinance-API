namespace PersonalFinance.Domain.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    void Update(T entity);
    void Delete(T entity);
    Task<T> Get(int id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}