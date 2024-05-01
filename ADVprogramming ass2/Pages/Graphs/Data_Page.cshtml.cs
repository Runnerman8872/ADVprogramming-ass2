using ADVprogramming_ass2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ADVprogramming_ass2.Pages
{
    public class Data_PageModel : PageModel
    {
        private readonly AppDBContext _dbConnection;
        public string TasksJson { get; set; }

        public Data_PageModel(AppDBContext db)
        {
            _dbConnection = db;
        }

        public void OnGet()
        {
            var items = _dbConnection.Item.ToList();
            TasksJson = JsonSerializer.Serialize(items.Select(T => new { QuantSold = T.QuantSold, T.Item_Name }));
        }
    }
}
