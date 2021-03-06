﻿using OxiFin.Application.AppServices;
using OxiFin.ViewModels.AppObjects;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JwtAuth;

namespace OxiFin.Auth.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserAppService _appService;

        public UserController(UserAppService appService)
        {
            _appService = appService;
        }

        [HttpPost("SignUp")]
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

        [Authorize(Roles = "Administrator")]
        [HttpPost("Desative")]
        public async Task<IActionResult> Desative(long id)
        {
            await _appService.DesativateAsync(id);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(long userId, string roleName)
        {
            var result = await _appService.AddUserToRole(userId, roleName);
            return ReturnResult(result);
        }
    }
}
