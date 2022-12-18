using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
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
            try
            {
                string email = User.FindFirst(ClaimTypes.Email)?.Value;
                ResultBoardViewModel result = _boardService.BoardCreate(model, email);

                if (result.ErrorMessage != null)
                {
                    return BadRequest(result.ErrorMessage);
                }

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("api/UserBoardsList")]
        [HttpGet]
        public IActionResult ListUserBoards()
        {
            try
            {
                string email = User.FindFirst(ClaimTypes.Email)?.Value;

                var result = _boardService.GetBoardList(email);
                return Ok(result.Select(s => new
                {
                    Id = s.BoardId,
                    Name = s.Board.Name
                }
                ).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
