using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPut]
        public IActionResult Create(CreateBoardViewModel model)
        {
            ResultBoardViewModel result = _boardService.BoardCreate(model);

            if (result.ErrorMessage != null)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok();
        }


        [Route("api/UsersList")]
        [HttpGet]
        public IActionResult ListUsers(string email)
        {
            var result = _boardService.GetBoardList(email);
            return Ok(result);
        }
    }
}
