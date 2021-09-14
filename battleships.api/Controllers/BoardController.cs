using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace battleships.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {

        private readonly ILogger<BoardController> _logger;

        public BoardController(ILogger<BoardController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// create a board (only 1 allowed)
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="500">Server Error</response>
        [HttpGet("[action]")]
        public async Task<ActionResult> Create()
        {
             return await Task.FromResult( new JsonResult( new {
                    status = "ok"
                }));
        }
    }
}
