namespace HumanHabit.Domain.Entities;

public class Habit
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Status Status { get; set; }
}

public enum Status
{
    Active,
    Inactive,
    Completed
}