﻿using Microsoft.AspNetCore.Mvc;
using OxiFin.Application.AppServices;
using OxiFin.Common.InternalObjects;
using OxiFin.ViewModels.AppObject;
using OxiFin.ViewModels.AppObjects;
using System.Threading.Tasks;

namespace OxiFin.Api.Controllers
{
    public class DebitController : BaseController
    {
        private readonly DebitAppService _appService;

        public DebitController(DebitAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _appService.FindByIdAsync(id);
            return ReturnResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Debit_vw request)
        {
            var result = await _appService.AddAsync(request);
            return ReturnResult(result);
        }
        
        [HttpPut]
        public IActionResult Put(Debit_vw request)
        {
            _appService.Update(request);
            return ReturnResult(new AppResult());
        }
    }
}