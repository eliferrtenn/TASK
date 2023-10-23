using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using VardabitCore.Business.Interfaces;
using VardabitCore.Business.Models.Requests.AccountRequests;

namespace VardabitCore.API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService acccountService)
        {
            _accountService = acccountService;
        }

        /// <summary>
        /// Giriş işlemi yapar
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _accountService.SignIn(request);
            return Ok(result);
        }

        /// <summary>
        /// Çıkış işlemi yapar
        /// </summary>
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Ok(new { message = "Çıkış yapıldı." });
        }

        /// <summary>
        /// Giriş yapılan kullanıcıyı getirir
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var result = await _accountService.GetUser();
            return Ok(result);
        }
        /// <summary>
        /// Yeni bir kullanıcı ekler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterRequest request)
        {
            var result = await _accountService.RegisterUser(request);
            return Ok(result);
        }

        /// <summary>
        /// Var olan kullanıcıyı günceller
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateUser(EditUserRequest request)
        {
            var result = await _accountService.EditUser(request);
            return Ok(result);
        }
    }
}

