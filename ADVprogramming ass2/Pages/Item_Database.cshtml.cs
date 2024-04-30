using ADVprogramming_ass2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADVprogramming_ass2.Pages
{
    public class Item_DatabaseModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<ItemsOnSaleModel> Items { get; set; }

        private readonly AppDBContext _dbConnection;

        public Item_DatabaseModel(ILogger<IndexModel> logger, AppDBContext _db)
        {
            _logger = logger;

            _dbConnection = _db;
        }

        public void OnGet()
        {
            Items = _dbConnection.Item.ToList();
        }
    }
}
