using FinEx.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEx.Application.Users.Commands
{
    public class DeleteUserCommandHandler
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUserCommand command)
        {
            await _userRepository.DeleteAsync(command.Id);
        }
    }
}
