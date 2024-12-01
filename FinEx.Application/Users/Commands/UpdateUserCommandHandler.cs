using FinEx.Core.Entities;
using FinEx.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEx.Application.Users.Commands
{
    public class UpdateUserCommandHandler
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand command)
        {
            var user =await  _userRepository.GetByIdAsync(command.Id);
            if (user != null)
            {
                user.Username=command.UserName;
                user.Password=command.Password;
                await _userRepository.UpdateAsync(user);
            }
        }
    }
}
