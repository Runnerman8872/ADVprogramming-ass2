using ADVprogramming_ass2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ADVprogramming_ass2.Pages
{
    public class Item_Sale_pageModel : PageModel
    {
        private readonly AppDBContext _dbConnection;

        public ItemsOnSaleModel Items { get; set; }

        public Item_Sale_pageModel(AppDBContext context)
        {
            _dbConnection = context;
        }

        public void OnGet(Guid id)
        {
            Items = _dbConnection.Item.FirstOrDefault(t => t.Item_Id == id);
        }

    }
}
