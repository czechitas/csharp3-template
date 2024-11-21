namespace ToDoList.Persistence.Repositories;

public interface IRepository<T> where T : class
{
    public void Create(T item);
    public IEnumerable<T> ReadAll();
    public T? ReadById(int id);
    public void Update(T item);
    public void Delete(T item);
}
public interface IRepositoryAsync<T> where T : class
{
    public Task CreateAsync(T item);
    public  Task<IEnumerable<T>> ReadAllAsync();
    public Task<T?> ReadByIdAsync(int id);
    public Task  UpdateAsync(T item);
    public Task DeleteAsync(T item);
}
