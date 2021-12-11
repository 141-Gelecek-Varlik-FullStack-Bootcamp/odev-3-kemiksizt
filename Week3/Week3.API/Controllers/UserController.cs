using Microsoft.AspNetCore.Mvc;
using Week3.Model;
using Week3.Model.User;
using Week3.Service.User;

namespace Week3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost("Delete")]
        public General<UserViewModel> DeleteUser(int id, [FromBody] UserViewModel user)
        {
            return userService.DeleteUser(id, user);
        }

        [HttpPost("Login")]
        public General<UserLoginViewModel> Login([FromBody] UserLoginViewModel user)
        {
            return userService.Login(user);
        }

        [HttpPost("Insert")]
        public General<UserViewModel> InsertUser([FromBody] UserViewModel newUser)
        {
            return userService.InsertUser(newUser);
        }

        [HttpGet]
        public General<UserViewModel> GetUsers()
        {
            return userService.GetUsers();
        }

        [HttpPut("{id}")]
        public General<UserViewModel> UpdateUser(int id, [FromBody] UserViewModel user)
        {
            return userService.UpdateUser(id, user);
        }
        /*
        [HttpDelete("{id}")]
        public General<UserViewModel> DeleteUser(int id)
        {
            return userService.DeleteUser(id);
        }
        */
    }



}
