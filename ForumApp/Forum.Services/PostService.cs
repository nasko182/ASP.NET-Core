
namespace Forum.Services;

using Microsoft.EntityFrameworkCore;

using Data.Models.Models;
using ViewModels.Post;
using Interfaces;
using Data;

public class PostService : IPostService
{
    private readonly ForumDbContext _dbContext;

    public PostService(ForumDbContext dbContext)
    {
            _dbContext = dbContext;
    }

    public async Task<IEnumerable<PostViewModel>> ListAllAsync()
    {
        IEnumerable<PostViewModel> allPost = await _dbContext
            .Posts
            .OrderByDescending(p=>p.Id)
            .Select(p => new PostViewModel()
            {
                Id = p.Id.ToString(),
                Title = p.Title,
                Content = p.Content
            })
            .ToArrayAsync();

        return allPost;
    }

    public async Task AddPostAsync(PostFormViewModel postViewModel)
    {
        Post newPost = new Post()
        {
            Title = postViewModel.Title,
            Content = postViewModel.Content
        };

        await this._dbContext.Posts.AddAsync(newPost);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task<PostFormViewModel> GetPostByIdAsync(string id)
    {
        Post currentPost = await _dbContext
            .Posts
            .FirstAsync(p=>p.Id.ToString()==id);
        
        return new PostFormViewModel()
        {
            Title = currentPost.Title,
            Content = currentPost.Content
        };
    }

    public async Task EditPostAsync(string id, PostFormViewModel postViewModel)
    {
        Post currentPost = await _dbContext
            .Posts
            .FirstAsync(p => p.Id.ToString() == id);

        currentPost.Title = postViewModel.Title;
        currentPost.Content = postViewModel.Content;

        await this._dbContext.SaveChangesAsync();
    }

    public async Task DeletePostAsync(string id)
    {
        Post currentPost = await _dbContext
            .Posts
            .FirstAsync(p => p.Id.ToString() == id);


        this._dbContext.Remove(currentPost);
        await this._dbContext.SaveChangesAsync();
    }
}