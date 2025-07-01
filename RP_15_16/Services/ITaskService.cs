using RP_15_16.Models;

namespace RP_15_16.Services
{
	public interface ITaskService
	{
		List<UserTask> GetAllTasks();
		UserTask? GetTaskById(int taskId);
		void ChangeTaskStatus(int taskId);
		void AddTask(string title, string? description, DateTime? expires);
		void DeleteTask(int taskId);

	}
}
