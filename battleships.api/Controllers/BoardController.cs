using System.Threading.Tasks;
using battleships.application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

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
        public async Task<IActionResult> Create()
        {
            var str = JsonConvert.SerializeObject(new bool?[10,10]);

            return await Task.FromResult(Ok(str));
        }

        /// <summary>
        /// adds a ship to the board for a team. (can't overlap)
        /// </summary>
        /// <param name="team">The team adding the ship</param>
        /// <param name="x">x start index on a 10 by 10 zero based index board</param>
        /// <param name="y">y start index</param>
        /// <param name="direction">down or across from the start index</param>
        /// <param name="length">the ship size</param>
        /// <response code="200">Success</response>
        /// <response code="500">Server Error</response>
        [HttpGet("[action]")]
        public async Task<ActionResult> AddShip(Team team, int x, int y, Direction direction, int length)
        {
              return await Task.FromResult(new OkResult());
        }

        /// <summary>
        /// adds a ship to the board for a team. (can't overlap)
        /// </summary>
        /// <param name="fromTeam">The team attacking the ship</param>
        /// <param name="x">x index on a 10 by 10 zero based index board</param>
        /// <param name="y">y index</param>
        /// <response code="200">Success</response>
        /// <response code="500">Server Error</response>
        [HttpGet("[action]")]
        public async Task<ActionResult> Attack(Team fromTeam, int x, int y)
        {
             return await Task.FromResult(new OkResult());
        }
    }
}
