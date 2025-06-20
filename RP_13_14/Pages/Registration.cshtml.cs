using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RP_13_14.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "������� ���")]
        public string Name { get; set; }

        [BindProperty]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "������� Email")]
		public string Email { get; set; }

		[BindProperty]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "������� ������")]
        [MinLength(8, ErrorMessage = "������ ������ ���� ������ �� ����� 8 ��������")]
		public string Password { get; set; }

        [BindProperty]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "����������� ������")]
        [Compare(nameof(Password))]
		public string ConfirmedPassword { get; set; }

        public string? Message { get; private set; }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            Message = "�� ����������������!";
        }
    }
}
