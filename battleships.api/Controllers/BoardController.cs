using System.Threading.Tasks;
using battleships.application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using EnsureThat;

namespace battleships.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {

        private readonly ILogger<BoardController> logger;
        private readonly BattleshipService battleshipService;

        public BoardController(ILogger<BoardController> logger, BattleshipService battleshipService)
        {
            this.logger = logger;
            this.battleshipService = battleshipService;
        }

        /// <summary>
        /// create a board (only 1 allowed)
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="304">Not modified - board already created</response>
        /// <response code="500">Server Error</response>
        [HttpGet("[action]")]
        public async Task<IActionResult> Create()
        {
            var success = await battleshipService.CreateBoard();

            if (success)
                return Ok();
            else
                return StatusCode(304);
        }

        /// <summary>
        /// adds a ship to the board for a team. (can't overlap)
        /// </summary>
        /// <param name="team">The team adding the ship - team1 = 0 , team2 = 1</param>
        /// <param name="x">x start index on a 10 by 10 zero based index board</param>
        /// <param name="y">y start index</param>
        /// <param name="direction">down or across from the start index - down = 0 , accross = 1</param>
        /// <param name="length">the ship size</param>
        /// <response code="200">Success - returns the board as a 2d array json value (not true json)</response>
        /// <response code="400">The parameter combination doesn't work</response>
        /// <response code="500">Server Error</response>
        [HttpGet("[action]")]
        public async Task<ActionResult> AddShip(Team team, int x, int y, Direction direction, int length)
        {
            Ensure.That(x).IsInRange(0, 9);
            Ensure.That(y).IsInRange(0, 9);
            Ensure.That((int)team).IsInRange(0, 1);
            Ensure.That(length).IsInRange(1, 10);
            var board = await battleshipService.AddShip(team, x, y, direction, length);
            var str = JsonConvert.SerializeObject(board);
            return Ok(str);
        }

        /// <summary>
        /// attempts to attack a ship on the board.
        /// </summary>
        /// <param name="fromTeam">The team attacking the ship - team1 = 0 , team2 = 1</param>
        /// <param name="x">x index on a 10 by 10 zero based index board</param>
        /// <param name="y">y index</param>
        /// <response code="200">Success - with a vlaue "hit" or "miss"</response>
        /// <response code="400">The parameter combination doesn't work</response>
        /// <response code="500">Server Error</response>
        [HttpGet("[action]")]
        public async Task<ActionResult> Attack(Team fromTeam, int x, int y)
        {
            Ensure.That(x).IsInRange(0, 9);
            Ensure.That(y).IsInRange(0, 9);
            Ensure.That((int)fromTeam).IsInRange(0, 1);
            var result = await battleshipService.Attack(fromTeam,x,y);
            
            return Ok(result);
        }
    }
}
