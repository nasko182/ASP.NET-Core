
namespace Forum.Services.Interfaces;

using ViewModels.Post;

public interface IPostService
{
    Task<IEnumerable<PostViewModel>> ListAllAsync();

    Task AddPostAsync(PostFormViewModel postViewModel);

    Task<PostFormViewModel> GetPostByIdAsync(string id);

    Task EditPostAsync(string id, PostFormViewModel postViewModel);

    Task DeletePostAsync(string id);
}