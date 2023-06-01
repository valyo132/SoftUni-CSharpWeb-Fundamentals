using ForumApp.Services.Contracts;
using ForumApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> All()
        {
            var posts = await _postService.GetAllPosts();
            return View(posts);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPostViewModel post)
        {
            if (ModelState.IsValid)
            {
                await _postService.AddPost(post);
                return RedirectToAction("All");
            }

            return View(post);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var post = await _postService.GetPostById(id);
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, AddPostViewModel obj)
        {
            if (ModelState.IsValid)
            {
                await _postService.Edit(id, obj);

                return RedirectToAction("All");
            }

            return View(obj);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _postService.Delete(id);
            return RedirectToAction("All");
        }
    }
}
