using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP_15_16.Services;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using RP_15_16.Models;

namespace RP_15_16.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ITaskService _taskService;

		public bool ShowNewTaskForm { get; set; } = false;

		[BindProperty]
		[MaxLength(64, ErrorMessage = "Максивальная длина заголовка - 32 символа")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Введите заголовок задачи")]
		public string Title { get; set; }

		[BindProperty]
		[MaxLength(256, ErrorMessage = "Максивальная длина описания - 256 символов")]
		public string? Description { get; set; }

		[BindProperty]
		[DataType(DataType.DateTime)]
		public DateTime? Expires { get; set; }

		public IndexModel(ITaskService taskService)
		{
			_taskService = taskService;
		}

		public IActionResult OnPostCreateTask()
		{
			if(!ModelState.IsValid)
			{
				ShowNewTaskForm = true;
				return Page();
			}

			_taskService.AddTask(Title, Description, Expires);
			return RedirectToPage("/index");
		}public IActionResult OnPostUpdateTask()
		{
			if(!ModelState.IsValid)
			{
				return Page();
			}

			_taskService.AddTask(Title, Description, Expires);
			return RedirectToPage("/index");
		}

		public IActionResult OnGetChangeTaskStatus(int taskId)
		{
			_taskService.ChangeTaskStatus(taskId);
			return Page();
		}
		public IActionResult OnGetDeleteTask(int taskId)
		{
			_taskService.DeleteTask(taskId);
			return Page();
		}
		public IActionResult OnGetGetTaskById(int taskId)
		{
			//Довольно плохое решение

			UserTask? task = _taskService.GetTaskById(taskId);
			string jsTaskDate = null;
			if (task.Expires != null) jsTaskDate = task.Expires.Value.ToString("yyyy-MM-ddTHH:mm");

			if (task != null)
			{
				string jsonTask = $"{{ \"Id\": \"{task.Id}\", \"Title\": \"{task.Title}\", \"Description\": \"{task.Description ?? null}\", \"Expires\": \"{jsTaskDate}\" }}";
				//return Content(JsonSerializer.Serialize(_taskService.GetTaskById(taskId)), "application/json; charset=utf-8");
				return Content(jsonTask, "application/json; charset=utf-8");
			}
			else
			{
				return new NotFoundResult();
			}
		}
	}
}
