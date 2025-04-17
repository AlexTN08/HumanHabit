using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HumanHabit.Domain.Entities;

namespace HumanHabit.Infrastructure.Configuration;

public sealed class HabitConfiguration : IEntityTypeConfiguration<Habit>
{
    public void Configure(EntityTypeBuilder<Habit> builder)
    {
        builder.HasKey(habit => habit.Id);
        builder.Property(habit => habit.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasIndex(habit => habit.Name).IsUnique();
        builder.Property(habit => habit.Description).HasMaxLength(500);
    }
}