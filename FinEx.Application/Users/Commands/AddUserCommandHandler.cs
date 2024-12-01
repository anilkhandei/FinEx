using FinEx.Core.Entities;
using FinEx.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEx.Application.Users.Commands
{
    public class AddUserCommandHandler
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(AddUserCommand command)
        {
            var user = new User
            {
                Username = command.Username,
                Password = command.Password,
            };
            await _userRepository.AddAsync(user);
        }
    }
}
