﻿using Microsoft.AspNetCore.Mvc;
using OxiFin.Application;
using System.Collections.Generic;
using System.Linq;

namespace OxiFin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase 
    {
        [NonAction]
        public ObjectResult ReturnResult(object response)
        {
            if (response == null)
                return NotFound(response);

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