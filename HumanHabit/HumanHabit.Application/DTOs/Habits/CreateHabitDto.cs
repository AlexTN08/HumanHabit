namespace HumanHabit.Application.DTOs.Habits;

public class CreateHabitDto
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}