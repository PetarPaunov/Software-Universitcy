using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Core.Contracts;
using TaskBoardApp.Core.Data;
using TaskBoardApp.Core.Models;
using TaskBoardApp.Core.Models.Tasks;

namespace TaskBoardApp.Core.Services
{
    public class BoardServices : IBoardServices
    {
        private readonly TaskBoardAppDbContext context;

        public BoardServices(TaskBoardAppDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<BoardViewModel> GetBoards()
        {
            var boards =  context.Boards
                    .Select(b => new BoardViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Tasks = b.Tasks.Select(t => new TaskViewModel
                        {
                            Id = t.Id,
                            Title = t.Title,
                            Description = t.Description,
                            Owner = t.Owner.UserName
                        })
                        .ToList()
                    })
                    .ToList();

            return boards;
        }

        public IEnumerable<TaskBoardModel> GetExistingBoards()
            => context.Boards.Select(b => new TaskBoardModel
            {
                Id = b.Id,
                Name = b.Name
            }).ToList();
    }
}
