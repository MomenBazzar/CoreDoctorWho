using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;
public class GenericRepository<T> where T : class
{
    protected readonly DoctorWhoCoreDbContext _context;
    public GenericRepository(DoctorWhoCoreDbContext context)
    {
        _context = context;
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }
    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        _context.SaveChanges();
    }
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        foreach (T entity in entities)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        _context.SaveChanges();
    }
}