﻿using Microsoft.AspNetCore.Mvc;
using OxiFin.Common.InternalObjects;
using System.Collections.Generic;
using System.Linq;

namespace OxiFin.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public ObjectResult ReturnResult(AppResult response)
        {
            if (response == null)
                return NotFound(response);
            else if (response.HasError)
                return Problem(response.Message);

            return Ok(response);
        }

        public ObjectResult ReturnResult<T>(AppResult<T> response) where T : class
        {
            if (response == null)
                return NotFound(response);
            else if (response.HasError)
                return Problem(response.Message);

            return Ok(response);
        }

        [NonAction]
        public ObjectResult ReturnResult(IEnumerable<object> response)
        {
            if (response == null || !response.Any())
                return NotFound(response);

            return Ok(response);
        }
    }
}