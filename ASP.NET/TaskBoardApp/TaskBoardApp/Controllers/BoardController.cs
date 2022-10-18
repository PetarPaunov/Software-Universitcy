using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Core.Contracts;
using TaskBoardApp.Core.Data;
using TaskBoardApp.Core.Models.Tasks;

namespace TaskBoardApp.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoardServices boardServices;

        public BoardController(IBoardServices _boardServices)
        {
            boardServices = _boardServices;
        }


        public IActionResult Index()
        {
            var model = new TaskFormModel()
            {
                Boards = boardServices.GetExistingBoards()
            };

            return View(model);
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
