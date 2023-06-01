using ForumApp.ViewModels;

namespace ForumApp.Services.Contracts
{
    public interface IPostService
    {
        Task<ICollection<PostViewModel>> GetAllPosts();
        Task AddPost(AddPostViewModel obj);
        Task<AddPostViewModel> GetPostById(string id);
        Task Edit(string id, AddPostViewModel model);
        Task Delete(string id);
    }
}
