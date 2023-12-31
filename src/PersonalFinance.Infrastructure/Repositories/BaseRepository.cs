using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Common;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infrastructure.Persistence;

namespace PersonalFinance.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;
   
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _context.AddAsync(entity, cancellationToken);     
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public async Task<T> Get(int id, CancellationToken cancellationToken)
    {
        var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return result ?? throw new NullReferenceException($"Entidade com Id {id} não encontrada.");
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);        
    }
}