using ForumAppCRUDOperations.Core.Contracts;
using ForumAppCRUDOperations.Core.Data;
using ForumAppCRUDOperations.Core.Models;
using ForumAppCRUDOperations.Core.Services;
using Microsoft.AspNetCore.Identity;
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

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await postService.FindById(id);

            if (post != null)
            {
                return View(post);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await postService.EditPost(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await postService.DeletePost(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
