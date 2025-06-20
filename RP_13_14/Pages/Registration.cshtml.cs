using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RP_13_14.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [BindProperty]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите Email")]
		public string Email { get; set; }

		[BindProperty]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(8, ErrorMessage = "Пароль должен быть длиной не менее 8 символов")]
		public string Password { get; set; }

        [BindProperty]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Подтвердите пароль")]
        [Compare(nameof(Password))]
		public string ConfirmedPassword { get; set; }

        public string? Message { get; private set; }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            Message = "Вы зарегистрированы!";
        }
    }
}
