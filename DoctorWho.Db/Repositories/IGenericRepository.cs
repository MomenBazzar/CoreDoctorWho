namespace DoctorWho.Db.Repositories
{
    public interface IGenericRepository<T>
    {
        public Task Add(T entity);
        public Task AddRange(IEnumerable<T> entities);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);
        public void Update(T entity);
        public void UpdateRange(IEnumerable<T> entities);
        public Task Save();
    }
}
