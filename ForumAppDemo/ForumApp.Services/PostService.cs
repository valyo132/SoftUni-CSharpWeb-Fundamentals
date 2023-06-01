using ForumApp.Data;
using ForumApp.Models;
using ForumApp.Services.Contracts;
using ForumApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ForumApp.Services
{
    public class PostService : IPostService
    {
        private ForumAppDbContext _context;

        public PostService(ForumAppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<PostViewModel>> GetAllPosts()
        {
            var posts = await _context.Posts
                .Select(x => new PostViewModel
                {
                    Id = x.Id.ToString(),
                    Title = x.Title,
                    Text = x.Text,
                })
                .ToListAsync();

            return posts;
        }

        public async Task<AddPostViewModel> GetPostById(string id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id.ToString() == id);

            return new AddPostViewModel()
            {
                Title = post.Title,
                Text = post.Text
            };
        }

        public async Task AddPost(AddPostViewModel obj)
        {
            var post = new Post
            {
                Title = obj.Title,
                Text = obj.Text,
            };

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(string id, AddPostViewModel model)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id.ToString() == id);
            post.Title = model.Title;
            post.Text = model.Text;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id.ToString() == id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
