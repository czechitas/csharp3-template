namespace ToDoList.Persistence.Repositories;

public interface IRepository<T>
    where T : class
{
    public void Create(T item);
}
