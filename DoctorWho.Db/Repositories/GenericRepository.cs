using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DoctorWhoCoreDbContext _context;

    public GenericRepository(DoctorWhoCoreDbContext context)
    {
        _context = context;
    }

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }
    public async Task AddRange(IEnumerable<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
    }
    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async void UpdateRange(IEnumerable<T> entities)
    {
        foreach (T entity in entities)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}