using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleLogin.Ui.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SimpleLogin.Ui.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ISimpleLoginAuth _authService;

        public LoginModel(ISimpleLoginAuth authService)
        {
            _authService = authService;
            Input = new InputModel();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string? ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string? Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var isValid = await _authService.ValidateUserAsync(Input.Username!, Input.Password!);

            if (isValid)
            {
                // In a real app, you would sign the user in here (e.g., Cookie Auth).
                // For this package, we assume succesful validation means we can redirect.
                // Or we could have an event/callback.
                // For now, let's redirect to root.
                return Redirect("/");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}
