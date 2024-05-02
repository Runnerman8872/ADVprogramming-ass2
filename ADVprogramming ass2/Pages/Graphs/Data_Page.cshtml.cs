using ADVprogramming_ass2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Reflection.Metadata;

namespace ADVprogramming_ass2.Pages.Graphs
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
            TasksJson = JsonSerializer.Serialize(items.Select(t => new { Quantity_Sold = t.Item_Name, t.QuantSold}));
        }
    }
}
