namespace Forum.App.Controllers;

using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;
using ViewModels.Post;

public class PostController : Controller
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        this._postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        IEnumerable<PostViewModel> allPosts = await _postService.ListAllAsync();

        return View(allPosts);
    }


    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(PostFormViewModel postModel)
    {
        if (!ModelState.IsValid)
        {
            return View(postModel);
        }

        try
        {
            await this._postService.AddPostAsync(postModel);
        }
        catch (Exception)
        {
            ModelState.AddModelError(String.Empty, "Unexpected error");
            return View(postModel);
        }

        return RedirectToAction("All", "Post");
    }


    public async Task<IActionResult> Edit(string id)
    {
        try
        {
            PostFormViewModel post = await _postService.GetPostByIdAsync(id);

            return View(post);
        }
        catch (Exception)
        {
            return RedirectToAction("All");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, PostFormViewModel postModel)
    {
        if (!ModelState.IsValid)
        {
            return View(postModel);
        }

        try
        {
            await this._postService.EditPostAsync(id, postModel);
        }
        catch (Exception)
        {
            ModelState.AddModelError(String.Empty, "Unexpected error");
            return View(postModel);
        }

        return RedirectToAction("All", "Post");
    }


    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            PostFormViewModel post = await _postService.GetPostByIdAsync(id);

            return View(post);
        }
        catch (Exception)
        {
            return RedirectToAction("All","Post");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id, PostFormViewModel postModel)
    {
        try
        {
            await this._postService.DeletePostAsync(id);
        }
        catch (Exception)
        {
            ModelState.AddModelError(String.Empty, "Unexpected error");
            return View(postModel);
        }

        return RedirectToAction("All", "Post");
    }
}

