using HigherLowerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HigherLowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private static Game game;

        public GameController()
        {
            if (game == null)
            {
                game = new Game();
            }
        }

        [HttpPost("start")]
        public IActionResult StartGame()
        {
            game.StartGame();
            return Ok(game.GetGameState());
        }

        [HttpPost("guess")]
        public IActionResult MakeGuess([FromBody] GuessRequest guessRequest)
        {
            if (string.IsNullOrEmpty(guessRequest.Guess))
            {
                return BadRequest("Game is required");
            }

            var result = game.MakeGuess(guessRequest.Guess);

            return Ok(result);
        }

        [HttpGet("state")]
        public IActionResult GetGameState()
        {
            return Ok(game.GetGameState());
        }

    }
}
