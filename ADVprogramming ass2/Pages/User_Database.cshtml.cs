using ADVprogramming_ass2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADVprogramming_ass2.Pages
{
    public class User_DatabaseModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<UserModel> Users { get; set; }

        private readonly AppDBContext _dbConnection;

        public User_DatabaseModel(ILogger<IndexModel> logger, AppDBContext _db)
        {
            _logger = logger;

            _dbConnection = _db;
        }

        public void OnGet()
        {
            Users = _dbConnection.User_Name.ToList();
        }
    }
}
