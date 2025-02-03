using MediatR;
using TaskManager.Domain.Interfaces;
using TaskManager.Infrastructure.Dtos;

namespace TaskManager.Application.Tasks;

public record CreateTaskCommand(TaskDto taskDto) : IRequest<Unit>;

internal sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Unit>
{
    private readonly ITaskRepository taskRepository;

    public CreateTaskCommandHandler(ITaskRepository taskRepository)
    {
        this.taskRepository = taskRepository;
    }

    public async Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var task = Domain.Entities.Task.Create(
                request.taskDto.Title,
                request.taskDto.Description,
                request.taskDto.Status);

            await this.taskRepository.CreateTask(task);

            return Unit.Value;
        }
        catch (Exception ex)
        {
            // TODO: ADD LOGGER
            throw;
        }
    }
}
