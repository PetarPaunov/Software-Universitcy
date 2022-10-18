using TaskBoardApp.Core.Models;
using TaskBoardApp.Core.Models.Tasks;

namespace TaskBoardApp.Core.Contracts
{
    public interface IBoardServices
    {
        IEnumerable<BoardViewModel> GetBoards();
        IEnumerable<TaskBoardModel> GetExistingBoards();

        string GetUserId();
    }
}
