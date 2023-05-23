using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Service;
using Handcom.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

namespace Handcom.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;
        private readonly IMemoryCache _cache;


        public LoginController(IUserService userService, ISessionService sessionService, IMemoryCache memory)
        {
            _userService = userService;
            _sessionService = sessionService;
            _cache = memory;
        }

        [HttpGet]
        public IActionResult Index(int userId)
        {
            var sessionGet = _sessionService.GetSession(userId);
            if (sessionGet != null)
            {
                sessionGet.IsActive = false;
                _cache.Set<int?>("user", null);
                _sessionService.IncludeSession(sessionGet);
            }

            return View();
        }

        [HttpPost("entrar")]
        public IActionResult Entrar(string Email, string Password)
        {
            var userValid = _userService.ValidateUser(Email, Password);

            if (userValid)
            {
                var user = _userService.GetUserByEmail(Email);
                var sessionGet = _sessionService.GetSession(user.Id);

                if (sessionGet != null && sessionGet.IsActive)
                    return Ok(sessionGet);
                else if (sessionGet != null)
                {
                    sessionGet.IsActive = true;
                    _sessionService.IncludeSession(sessionGet);
                    return Ok(sessionGet);
                }
                else
                {
                    var session = new Session() { Name = user.Name, IsActive = true, UserId = user.Id };
                    _sessionService.IncludeSession(session);

                    return Ok(session);
                }
            }
            else
                return BadRequest("usuário ou senha invalidos.");

        }

        [HttpGet("registro")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("registrar")]
        public IActionResult Registering(RegisterViewModel register)
        {
            if (register.Email is null || register.Password is null || register.ConfirmPassword is null || register.Name is null)
                return RedirectToAction("Register");

            if (register.Password != register.ConfirmPassword)
                return RedirectToAction("Register");

            var account = _userService.ValidateEmail(register.Email);

            if (!account)
            {
                var user = new Users() { Email = register.Email, Name = register.Name, Password = register.Password, CreatedAt = System.DateTime.Now };
                _userService.Insert(user);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Register");

        }
    }
}
