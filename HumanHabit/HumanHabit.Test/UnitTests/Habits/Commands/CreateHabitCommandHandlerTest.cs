using Moq;
using HumanHabit.Application.Common.Interfaces;
using HumanHabit.Application.DTOs.Habits;
using HumanHabit.Application.Habits.Commands;
using HumanHabit.Domain.Exceptions.Habit;

namespace HumanHabit.Test.UnitTests.Habits.Commands;

public class CreateHabitCommandHandlerTest
{
    private readonly Mock<IHabitRepository> _repositoryMock = new();

    #region Handling business logic

    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenHabitNameAlreadyExists()
    {
        // Arrange
        var createHabitDto = new CreateHabitDto
        {
            Name = "Name",
            Description = "Description"
        };
        var command = new CreateHabitCommand(createHabitDto);

        _repositoryMock.Setup(s => s
                .AnyByNameAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);
        
        var handler = new CreateHabitCommandHandler(_repositoryMock.Object);
        
        // Act
        var exception = await Assert.ThrowsAnyAsync<HabitAlreadyExistsExceptions>(async () => await handler.Handle(command, CancellationToken.None));

        // Assert
        Assert.Equal($"Habit with name {createHabitDto.Name} already exists", exception.Message);
    }
    
    [Fact]
    public async Task Handle_ShouldReturnDto_WhenHabitIsCreated()
    {
        // Arrange
        var createHabitDto = new CreateHabitDto
        {
            Name = "Name",
            Description = "Description"
        };
        var command = new CreateHabitCommand(createHabitDto);

        _repositoryMock.Setup(s => s
                .AnyByNameAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);
        
        var handler = new CreateHabitCommandHandler(_repositoryMock.Object);
        
        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(createHabitDto.Name, result.Name);
        Assert.Equal(createHabitDto.Description, result.Description);
    }

    #endregion
}