using FinEx.Core.Entities;
using FinEx.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEx.Application.Users.Commands
{
    public class GetAllUsersQueryHandler
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery command)
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
