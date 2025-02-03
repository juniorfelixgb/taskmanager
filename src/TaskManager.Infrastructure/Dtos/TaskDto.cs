using TaskManager.Domain.Enums;

namespace TaskManager.Infrastructure.Dtos;

public record TaskDto(
    string Title,
    string Description,
    Status Status);
