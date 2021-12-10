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

        [HttpPost("login")]
        public General<UserViewModel> Login([FromBody] UserViewModel user)
        {
            return userService.Login(user);
        }

        [HttpPost]
        public General<UserViewModel> Insert([FromBody] UserViewModel newUser)
        {
            return userService.Insert(newUser);
        }

        [HttpGet]
        public General<UserViewModel> GetUsers()
        {
            return userService.GetUsers();
        }

        [HttpPut("{id}")]
        public General<UserViewModel> Update(int id, [FromBody] UserViewModel user)
        {
            return userService.Update(id, user);
        }

        [HttpDelete("{id}")]
        public General<UserViewModel> Delete(int id)
        {
            return userService.Delete(id);
        }
    }



}
