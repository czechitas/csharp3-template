namespace ToDoList.Persistence.Audit;

public interface IAudit
{
    public void StoreAudit(string message);
}
