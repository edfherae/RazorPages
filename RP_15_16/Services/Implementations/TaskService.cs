using RP_15_16.Models;
using RP_15_16.Exceptions;

namespace RP_15_16.Services.Implementations
{
	public class TaskService : ITaskService
	{
		List<UserTask> _tasks = new List<UserTask>();
		public int NextTaskId { get; private set; } = 1;
		public List<UserTask> GetAllTasks()
		{
			return _tasks;
		}
		public UserTask? GetTaskById(int taskId)
		{
			foreach(UserTask task in _tasks)
			{
				if(task.Id == taskId) return task;
			}
			//throw new TaskNotFoundException(taskId);
			return null;
		}
		public void ChangeTaskStatus(int taskId)
		{
			UserTask? task = GetTaskById(taskId);

			if(task == null) throw new TaskNotFoundException(taskId);

			task.IsCompleted = !task.IsCompleted;
		}
		public void AddTask(string title, string? description, DateTime? expires)
		{
			_tasks.Add(new UserTask()
			{
				Id = NextTaskId++,
				Title = title,
				Description = description,
				Expires = expires
			});
		}
		public void DeleteTask(int taskId)
		{
			for(int i = 0; i < _tasks.Count; i++)
			{
				if (_tasks[i].Id == taskId)
				{
					_tasks.RemoveAt(i);
					return;
				}

			}
		}

	}
}
