using MediatR;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Tasks;

public record GetAllTasksQuery() : IRequest<IEnumerable<Domain.Entities.Task>>;
internal sealed class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<Domain.Entities.Task>>
{
    private readonly ITaskRepository taskRepository;

    public GetAllTasksQueryHandler(ITaskRepository taskRepository)
    {
        this.taskRepository = taskRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Task>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var tasks = await this.taskRepository.GetAll();
            if (tasks is null)
            {
                throw new ArgumentNullException(nameof(tasks));
            }

            return tasks;
        }
        catch (Exception ex)
        {
            // TODO: ADD LOGGER
            throw;
        }
    }
}
