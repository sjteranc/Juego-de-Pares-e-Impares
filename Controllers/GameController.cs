using Microsoft.AspNetCore.Mvc;
using ParImpar.DTOs;
using ParImpar.Services;

namespace ParImpar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("setPlayer1Name")]
        public IActionResult SetPlayer1Name([FromBody] PlayerNameRequest request)
        {
            _gameService.SetPlayer1Name(request.Name);
            return Ok("Player 1 name set successfully.");
        }

        [HttpPut("updatePlayer1Name")]
        public IActionResult UpdatePlayer1Name([FromBody] PlayerNameRequest request)
        {
            _gameService.SetPlayer1Name(request.Name);
            return Ok("Player 1 name updated successfully.");
        }

        [HttpPost("play")]
        public IActionResult PlayGame([FromBody] GameRequest request)
        {
            var result = _gameService.PlayGame(request.Player1Choice);
            return Ok(result);
        }

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            var status = _gameService.GetStatus();
            return Ok(status);
        }

        [HttpGet("state")]
        public IActionResult GetGameState()
        {
            var state = _gameService.GetGameState();
            return Ok(state);
        }


        [HttpDelete("reset")]
        public IActionResult ResetGame()
        {
            _gameService.ResetGame();
            return Ok("Game has been reset.");
        }
    }
}
