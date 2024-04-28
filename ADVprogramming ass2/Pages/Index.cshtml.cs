using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ADVprogramming_ass2.Model;

namespace ADVprogramming_ass2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<ItemsOnSaleModel> Items { get; set; }

        private readonly AppDBContext _dbConnection;

        public IndexModel(ILogger<IndexModel> logger, AppDBContext _db)
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