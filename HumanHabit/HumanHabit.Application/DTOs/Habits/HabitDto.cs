using HumanHabit.Domain.Entities;

namespace HumanHabit.Application.DTOs.Habits;

public class HabitDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public Status Status { get; set; }
}