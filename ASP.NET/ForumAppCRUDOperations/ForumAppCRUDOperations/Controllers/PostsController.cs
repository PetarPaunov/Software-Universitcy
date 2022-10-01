using ForumAppCRUDOperations.Core.Contracts;
using ForumAppCRUDOperations.Core.Data;
using ForumAppCRUDOperations.Core.Models;
using ForumAppCRUDOperations.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumAppCRUDOperations.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService postService;

        public PostsController(IPostService _postService)
        {
            this.postService = _postService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await postService.GetAllPosts();

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var model = new AddPostViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await postService.AddPost(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
