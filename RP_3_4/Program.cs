using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SolidTask
{
	public class Order
	{
		public int Id { get; set; }
		public required string CustomerEmail { get; set; }
		public bool IsValid { get; set; }
	}

	public interface ICanWriteOrderToDB
	{
		void Save(Order order);
	}
	public interface IEmailSender
	{
		void SendEmail(string email, string message);
	}
	public interface IOrderValidator
	{
		bool IsValid(Order order);
	}
	public class SqlDatabase : ICanWriteOrderToDB
	{
		public void Save(Order order)
		{
			Console.WriteLine($"Saving order #{order.Id} to SQL database...");
		}
	}
	public class SmtpEmailSender : IEmailSender
	{
		public void SendEmail(string email, string message)
		{
			Console.WriteLine($"Sending email to {email}: {message}");
		}
	}
	public class OrderValidator : IOrderValidator
	{
		public bool IsValid(Order order)
		{
			return order.IsValid;
		}
}

	public class OrderService
	{
		private ICanWriteOrderToDB _database;
		private IEmailSender _emailSender;
		private IOrderValidator _validator;
		public OrderService(ICanWriteOrderToDB database, IEmailSender emailSender, IOrderValidator validator)
		{
			_database = database;
			_emailSender = emailSender;
			_validator = validator;
		}
		public bool ProcessOrder(Order order)
		{
			if (!_validator.IsValid(order))
				return false;

			_database.Save(order);
			_emailSender.SendEmail(order.CustomerEmail, "Order confirmed!");

			return true;
		}
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			Random random = new Random();
			OrderService orderService = new OrderService(new SqlDatabase(), new SmtpEmailSender(), new OrderValidator());

			for (int i = 0; i < 8; i++)
			{
				Order order = new Order()
				{
					Id = random.Next(),
					CustomerEmail = $"user{random.Next()}@example.ru",
					IsValid = true
				};

				orderService.ProcessOrder(order);
			}
		}
	}
}
