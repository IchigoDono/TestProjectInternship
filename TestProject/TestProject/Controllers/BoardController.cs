using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TasksTracker.Services;
using TasksTracker.ViewModels;

namespace TasksTracker.Controllers
{
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;
        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [Route("api/CreateBoard")]
        [HttpPost]
        public IActionResult Create([FromBody] CreateBoardViewModel model)
        {
            ResultBoardViewModel result = _boardService.BoardCreate(model);

            if (result.ErrorMessage != null)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok();
        }


        [Route("api/UserBoardsList")]
        [HttpGet]
        public IActionResult ListUserBoards(string email)
        {
            var result = _boardService.GetBoardList(email);
            return Ok(result.Select(s=> s.Board.Name).ToList());
        }
    }
}
