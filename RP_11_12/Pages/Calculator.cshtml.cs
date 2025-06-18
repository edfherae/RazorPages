using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RP_11_12.Pages
{
	public class CalculatorModel : PageModel
	{
		public string Result { get; private set; } = "";
		public string ErrorMessage { get; private set; } = null!;

		public void OnGet(string firstNumber, string operation, string secondNumber)
		{
			System.Globalization.CultureInfo userCulture = System.Globalization.CultureInfo.CurrentCulture;
			System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
			try
			{
				switch (operation)
				{
					case "+":
						Result = (double.Parse(firstNumber) + double.Parse(secondNumber)).ToString();
						break;
					case "-":
						Result = (double.Parse(firstNumber) - double.Parse(secondNumber)).ToString();
						break;
					case "*":
						Result = (double.Parse(firstNumber) * double.Parse(secondNumber)).ToString();
						break;
					case "/":
						if (int.Parse(secondNumber) == 0)
						{
							ErrorMessage = "На ноль делить нельзя!";
							break;
						}
						Result = (double.Parse(firstNumber) / double.Parse(secondNumber)).ToString();
						break;
				}
			}
			catch (FormatException ex)
			{
				ErrorMessage = $"Введите числа в поля для чисел";
			}
			catch (Exception ex) 
			{
				ErrorMessage = $"{ex.Message}";
			}
			System.Globalization.CultureInfo.CurrentCulture = userCulture;
		}
	}

}
