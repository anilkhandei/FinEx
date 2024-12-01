using FinEx.Application.Users.Commands;
using FinEx.Core.Entities;
using FinEx.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Users.Commands
{
    public class AddCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Add_User()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var handler = new AddUserCommandHandler(userRepositoryMock.Object);
            var command = new AddUserCommand { Username = "testuser", Password = "password" };

            //Act
            await handler.Handle(command);

            //Assert
            userRepositoryMock.Verify(repo=>repo.AddAsync(It.Is<User>(u=>u.Username=="testuser" && u.Password=="password")),Times.Once());
        }


        [Fact]
        public async Task Handle_Should_Update_User()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var handler=new UpdateUserCommandHandler(userRepositoryMock.Object);
            var command= new UpdateUserCommand { Id=1, UserName="testuserupdate",Password = "password2update" };

            var existingUser=new User { Id=1,Username="oldusername",Password="password"};
            userRepositoryMock.Setup(repo=>repo.GetByIdAsync(command.Id)).ReturnsAsync(existingUser);

            //Act
            await handler.Handle(command);

            //Assert
            userRepositoryMock.Verify(repo => repo.GetByIdAsync(command.Id),Times.Once);
            userRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<User>(u => u.Id == command.Id && u.Username == "testuserupdate" && u.Password == "password2update")), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Delete_User()
        {
            //Arrange
            var userRepositoryMock= new Mock<IUserRepository>();
            var handler=new DeleteUserCommandHandler(userRepositoryMock.Object);
            var command = new DeleteUserCommand { Id = 1 };

            userRepositoryMock.Setup(repo => repo.DeleteAsync(command.Id));

            //Act
            await handler.Handle(command);

            //Assert
            userRepositoryMock.Verify(repo=>repo.DeleteAsync(command.Id), Times.Once);
        }

    }
}
