using ADVprogramming_ass2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System.Linq;

namespace ADVprogramming_ass2.Pages
{
    public class Shop_pageModel : PageModel
    {
        private readonly ILogger<Shop_pageModel> _logger;

        public List<ItemsOnSaleModel> Items { get; set; }

        private readonly AppDBContext _dbConnection;

        public Shop_pageModel(ILogger<Shop_pageModel> logger, AppDBContext _db)
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
