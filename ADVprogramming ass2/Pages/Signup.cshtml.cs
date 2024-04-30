using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ADVprogramming_ass2.Model;

namespace ADVprogramming_ass2.Pages
{
    public class SignupModel : PageModel
    {
        private readonly AppDBContext _dbConnection;
        public UserModel NewUser { get; set; }

        public SignupModel(AppDBContext context)
        {
            _dbConnection = context;
        }

        public void OnGet()
        {
            NewUser = new UserModel();
        }
        public IActionResult OnPost(UserModel NewUser)

        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbConnection.User_Name.Add(NewUser);
            _dbConnection.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
