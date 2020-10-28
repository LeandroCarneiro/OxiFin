using OxiFin.Application.AppServices;
using OxiFin.ViewModels.AppObjects;
using Microsoft.AspNetCore.Mvc;

namespace OxiFin.Api.Controllers
{
    public class SurveyController : BaseController
    {
        private readonly SurveyVersionAppService _appService;

        public SurveyController(SurveyVersionAppService appService)
        {
            this._appService = appService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return ReturnResult(_appService.FindById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] SurveyVersion_vw value)
        {
            return ReturnResult(_appService.Add(value));
        }

        [HttpPut]
        public IActionResult Put([FromBody] SurveyVersion_vw value)
        {
            _appService.Update(value);
            return Ok();
        }
    }
}
