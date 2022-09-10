namespace DoctorWho.Db.Repositories
{
    public interface IGenericRepository<T>
    {
        public void Add(T entity);
        public void AddRange(IEnumerable<T> entities);
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);
        public void Update(T entity);
        public void UpdateRange(IEnumerable<T> entities);
        public void Save();
    }
}
