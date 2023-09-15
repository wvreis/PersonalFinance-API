using PersonalFinance.Application.Accounts.Commands;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.ApplicationTests;

public class AddAccountCommandHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_AddsAccount()
    {
        // Arrange
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();

        var handler = new AddAccountCommandHandler(accountRepositoryMock.Object, unitOfWorkMock.Object);

        var request = new AddAccountCommand
        {
            Description = "Test Account",
            OpeningBalance = 1000,
            BankId = 1,
            AccountTypeId = 1
        };

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        accountRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Account>(), It.IsAny<CancellationToken>()), Times.Once);
        unitOfWorkMock.Verify(unitOfWork => unitOfWork.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        Assert.Equal(0, result);
    }
}