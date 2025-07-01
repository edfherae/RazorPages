namespace RP_15_16.Models
{
	public class UserTask
	{
		public required int Id { get; set; }
		public required string Title { get; set; }
		public string? Description { get; set; }
		public DateTime CreationDate { get; private set; } = DateTime.Now;
		public DateTime? Expires { get; set; }
		public bool IsCompleted { get; set; } = false;
	}
}
