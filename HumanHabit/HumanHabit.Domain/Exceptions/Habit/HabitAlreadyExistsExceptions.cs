namespace HumanHabit.Domain.Exceptions.Habit;

public sealed class HabitAlreadyExistsExceptions(string message) : Exception(message);