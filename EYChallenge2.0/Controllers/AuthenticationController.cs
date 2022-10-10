using EYChallenge2._0.Data.Repositories.Interfaces;
using EYChallenge2._0.Models;
using EYChallenge2._0.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EYChallenge2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private IUserRepository _userRepository;

        public AuthenticationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST api/<UserController>
        [HttpPost]
        public User Post([FromBody] LoginViewModel login)
        {
            return _userRepository.LoginUser(login);
        }
    }
}
