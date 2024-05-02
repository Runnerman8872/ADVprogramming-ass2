using ADVprogramming_ass2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ADVprogramming_ass2.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDBContext _context;

        public LoginModel(AppDBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public LoginInput Input { get; set; }

        public class LoginInput
        {
            [Required]
            [Display(Name = "UserName")]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
        }

        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _context.User_Name.FirstOrDefaultAsync(u => u.User_Name == Input.Username && u.Password == Input.Password);

            if (user == null)
            {
                Message = "InValid login attempt.";
                return Page();
            }
            var UIDtoString = user.User_Id.ToString();
            HttpContext.Session.SetString("UserId", UIDtoString);
            Message = "Login Successful.";
            return RedirectToPage("/Index");

        }

        public void OnGet()
        {
        }
    }
}
