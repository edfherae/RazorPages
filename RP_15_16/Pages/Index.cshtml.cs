using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP_15_16.Services;
using System.ComponentModel.DataAnnotations;

namespace RP_15_16.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ITaskService _taskService;

		public bool ShowNewTaskForm { get; set; } = false;

		[BindProperty]
		[MaxLength(64, ErrorMessage = "������������ ����� ��������� - 32 �������")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "������� ��������� ������")]
		public string Title { get; set; }

		[BindProperty]
		[MaxLength(256, ErrorMessage = "������������ ����� �������� - 256 ��������")]
		public string? Description { get; set; }

		[BindProperty]
		[DataType(DataType.DateTime)]
		public DateTime? Expires { get; set; }

		public IndexModel(ITaskService taskService)
		{
			_taskService = taskService;
		}

		public IActionResult OnPost()
		{
			if(!ModelState.IsValid)
			{
				ShowNewTaskForm = true;
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
	}
}
