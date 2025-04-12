namespace ToDoList.Persistence.Repositories;

public interface IRepository<T> where T : class
{
    public void Create(T item);
    public IEnumerable<T> ReadAll();
    public T? ReadById(int id);
    public void Update(T item);
    public void Delete(T item);
}
