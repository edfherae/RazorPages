using RP_15_16.Models;

namespace RP_15_16.Repositories
{
	public interface ITaskRepository
	{
		List<UserTask> GetAll();
		UserTask? GetById(int id);
		void CreateTask(UserTask task);
		void Delete(int id);
		void SaveChanges();
	}
}
