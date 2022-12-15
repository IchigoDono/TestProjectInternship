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


        public ResultBoardViewModel BoardCreate(CreateBoardViewModel model) 
        {
            ResultBoardViewModel result = new ResultBoardViewModel();

            bool existBoard = _applicationContext.Boards.Any(b => b.Name == model.Name);
            if (existBoard == true)
            {
                result.ErrorMessage ="Eror! Login Exist";
                return result;
            }

            Board board = new Board()
            {
                Name = model.Name,
                Description = model.Description,
                CreationDate = DateTime.Now,
                IsActive = true
            };

            _applicationContext.Boards.Add(board);
            int successfully = _applicationContext.SaveChanges();

            if (successfully == 0)
            {
                result.ErrorMessage = "Eror!";
                return result;
            }

            return result;
        }

        public List<ResultBoardViewModel> GetBoardList(string email)
        {
           User user = _applicationContext.Users.FirstOrDefault(s => s.Email == email);
           List<ResultBoardViewModel> users = _applicationContext.Users.Select(s => new ResultBoardViewModel() { Name = s.Name }).ToList();

            return users;
        }


    }
}
