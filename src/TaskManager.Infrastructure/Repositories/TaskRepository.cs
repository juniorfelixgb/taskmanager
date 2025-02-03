using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Interfaces;
using TaskManager.Infrastructure.Contexts;

namespace TaskManager.Infrastructure.Repositories;

internal sealed class TaskRepository : ITaskRepository
{
    private readonly AppDbContext context;

    public TaskRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task CreateTask(Domain.Entities.Task task)
    {
        await this.context.AddAsync(task);
        await this.context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Domain.Entities.Task>> GetAll()
    {
        return await this.context.Tasks.ToListAsync();
    }
}
