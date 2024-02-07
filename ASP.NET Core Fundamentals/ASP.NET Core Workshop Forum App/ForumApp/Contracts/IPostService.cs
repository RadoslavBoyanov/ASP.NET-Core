using ForumApp.Models;

namespace ForumApp.Contracts
{
	public interface IPostService
	{
		public Task<List<PostViewModel>> GetAllAsync();
		public Task AddPostAsync(PostFormModel postViewModel);

		public Task<PostFormModel> FindByIdAsync(int id);

		public Task EditPostAsync(int id, PostFormModel postViewModel);

		public Task DeletePostAsync(int id);
	}
}
