using RP_15_16.Models;

namespace RP_15_16.Repositories.Imlementations
{
	//Сделать абстрактным
	public class TaskRepository : ITaskRepository
	{
		public readonly List<UserTask> _tasks;
		private int _nextId; //другой сервис

		public TaskRepository()
		{
			_tasks = new List<UserTask>();
			_nextId = 1;
		}
		public List<UserTask> GetAll()
		{
			return _tasks;
		}
		public UserTask? GetById(int id)
		{
			foreach (UserTask task in _tasks) 
			{
				if (task.Id == id) return task;
			}
			return null;
		}
		public void CreateTask(UserTask task)
		{
			_tasks.Add(task);
		}

		public void Delete(int id) //Переделать в поиск по индексу
		{
			foreach (UserTask task in _tasks)
			{
				if (task.Id == id) _tasks.Remove(task);
			}
		}

		public void SaveChanges()
		{
			throw new NotImplementedException();
		}
	}
}
