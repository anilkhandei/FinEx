using FinEx.Application.Users.Commands;
using FinEx.Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FinEx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly GetUserByIdQueryHandler _getUserByIdHandler;
        private readonly AddUserCommandHandler _addUserCommandHandler;
        private readonly DeleteUserCommandHandler _deleteUserCommandHandler;
        private readonly UpdateUserCommandHandler _updateUserCommandHandler;
        private readonly GetAllUsersQueryHandler _getAllUsersCommandHandler;

        public UsersController(GetUserByIdQueryHandler getUserByIdHandler,AddUserCommandHandler addUserCommandHandler
            , UpdateUserCommandHandler updateUserCommandHandler, DeleteUserCommandHandler deleteUserCommandHandler,GetAllUsersQueryHandler getAllUsersQueryHandler)
        {
            _getUserByIdHandler = getUserByIdHandler;
            _addUserCommandHandler = addUserCommandHandler;
            _updateUserCommandHandler = updateUserCommandHandler;
            _deleteUserCommandHandler = deleteUserCommandHandler;
            _getAllUsersCommandHandler=getAllUsersQueryHandler;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _getUserByIdHandler
                        .Handle(new GetUserByIdQuery { Id = id });
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserCommand command)
        {
            await _addUserCommandHandler.Handle(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _updateUserCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _deleteUserCommandHandler.Handle(new DeleteUserCommand { Id = id });
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users= await _getAllUsersCommandHandler.Handle(new GetAllUsersQuery());
            return Ok(users);
        }
    }
}
