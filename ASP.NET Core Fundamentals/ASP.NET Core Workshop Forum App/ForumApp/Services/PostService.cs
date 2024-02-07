
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Services
{
	using ForumApp.Contracts;
	using ForumApp.Models;
	using ForumApp.Data;
	using ForumApp.Data.Models;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class PostService : IPostService
	{
		private readonly ForumAppDbContext _context;

		public PostService(ForumAppDbContext context)
		{
			_context = context;
		}

		public async Task AddPostAsync(PostFormModel postViewModel)
		{
			var postForAdd = new Post()
			{
				Title = postViewModel.Title,
				Content = postViewModel.Content,
			};

			await _context.Posts.AddAsync(postForAdd);
			await _context.SaveChangesAsync();
		}

		public async Task DeletePostAsync(int id)
		{
			Post post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
			post.IsDelete = true;
			await _context.SaveChangesAsync();
		}

		public async Task EditPostAsync(int id, PostFormModel postFormModel)
		{
			Post post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

			if (post != null)
			{
				post.Title = postFormModel.Title;
				post.Content = postFormModel.Content;
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new InvalidOperationException("Invalid post Id");
			}
		}

		public async Task<PostFormModel> FindByIdAsync(int id)
		{
			Post post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
			if (post != null)
			{
				return new PostFormModel()
				{
					Title = post.Title,
					Content = post.Content
				};
			}
			else
			{
				throw new InvalidOperationException("Invalid post Id");
			}
		}

		public async Task<List<PostViewModel>> GetAllAsync()
		{
			return await _context.Posts
				.Where(p => !p.IsDelete)
				.Select(p => new PostViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					Content = p.Content,
				}).ToListAsync();
		}
	}
}
