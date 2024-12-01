using FinEx.Core.Entities;
using FinEx.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEx.Application.Users.Queries
{
    public class GetUserByIdQueryHandler
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(GetUserByIdQuery query)
        {
            return await _userRepository.GetByIdAsync(query.Id);
        }
    }
}
