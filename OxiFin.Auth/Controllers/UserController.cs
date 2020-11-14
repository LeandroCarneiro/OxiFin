using OxiFin.Application.AppServices;
using OxiFin.ViewModels.AppObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace OxiFin.Auth.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserAppService _appService;

        public UserController(UserAppService appService)
        {
            _appService = appService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(UserApp_vw request)
        {
            var result = await _appService.SignUp(request);
            return ReturnResult(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(Login_vw request)
        {
            var result = await _appService.SignIn(request);
            return ReturnResult(result);
        }

        [HttpPost("Desative")]
        public async Task<IActionResult> Desative(long id)
        {
            await _appService.DesativateAsync(id);
            return Ok();
        }

        [HttpPost("User/{userEmail}/Role")]
        public async Task<IActionResult> AddUserToRole(string userName, [FromBody] string roleName)
        {
            var result = await _appService.AddUserToRole(userName, roleName);
            return ReturnResult(result);
        }
    }
}
