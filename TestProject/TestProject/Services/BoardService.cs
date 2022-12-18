using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using TasksTracker.Models;
using TasksTracker.ViewModels;

namespace TasksTracker.Services
{
    public class BoardService : IBoardService
    {
        private readonly TasksTrackerDBContext _applicationContext;
        public BoardService(TasksTrackerDBContext applicationContext)
        {
            _applicationContext = applicationContext;
        }


        public ResultBoardViewModel BoardCreate(CreateBoardViewModel model, string email)
        {
            ResultBoardViewModel result = new ResultBoardViewModel();

            bool existBoard = _applicationContext.Boards.Any(b => b.Name == model.Name);
            if (existBoard == true)
            {
                result.ErrorMessage = "Eror! Login Exist";
                return result;
            }

            var user = _applicationContext.Users.FirstOrDefault(s => s.Email == email);

            Board board = new Board()
            {
                Name = model.Name,
                Description = model.Description,
                CreationDate = DateTime.Now,
                IsActive = true
            };

            _applicationContext.Boards.Add(board);
            _applicationContext.UserBoards.Add(new UserBoard() { Board = board, UserId = user.UserId });
            var successfully = _applicationContext.SaveChanges();

            if (successfully == 0)
            {
                result.ErrorMessage = "Eror!";
                return result;
            }

            return result;
        }

        public List<UserBoard> GetBoardList(string email)
        {
            List<UserBoard> result = _applicationContext.UserBoards.Include(s => s.User)
                                                        .Include(s => s.Board)
                                                        .Where(s => s.User.Email == email).ToList();

            return result;
        }


    }
}
