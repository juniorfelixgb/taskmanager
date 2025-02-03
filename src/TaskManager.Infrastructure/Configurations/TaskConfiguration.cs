using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Enums;

namespace TaskManager.Infrastructure.Configurations;

internal sealed class TaskConfiguration : IEntityTypeConfiguration<Domain.Entities.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
    {
        builder.ToTable("task");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
               .HasMaxLength(50);

        builder.Property(t => t.Description)
               .HasMaxLength(100);

        builder.Property(t => t.Status)
               .HasMaxLength(20)
               .HasConversion(
                    s => s.ToString(),
                    s => Enum.Parse<Status>(s));
    }
}
