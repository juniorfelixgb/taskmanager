
namespace TaskManager.Domain.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<Entities.Task>> GetAll();
    Task CreateTask(Entities.Task task);
}
