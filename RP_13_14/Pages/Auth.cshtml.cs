using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RP_13_14.Pages
{
    public class AuthModel : PageModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "������� Email")]
        [BindProperty]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "������� ������"), MinLength(8, ErrorMessage = "������ ������ ���������� �� ����� 8 ��������")]
        [BindProperty]
        public string Password { get; set; } = null!;
		public string? Result { get; private set; }
        public int Iteration { get; private set; }
		public void OnPost()
        {
            Console.WriteLine(ModelState.IsValid);
            Iteration++;
            Console.WriteLine($"Iteration: {Iteration}");
            if (!ModelState.IsValid) 
            {
                return;
            }

            Result = "�� ������������";
        }
    }
}
