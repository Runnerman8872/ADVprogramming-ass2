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


        public Item_Sale_pageModel(AppDBContext context)
        {
            _dbConnection = context;
        }

        public ItemsOnSaleModel Items { get; set; }
        public int AMTSold;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Items = await _dbConnection.Item.FindAsync(id);
            //hjmyshghsshggh
            if (Items == null)
            {
                return NotFound();//hjmyshghsshggh
            }

            //hjmyshghsshggh
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var itemSold = await _dbConnection.Item.FindAsync(Items.Item_Id);

            if (itemSold == null)
            {
                return NotFound();
            }

            itemSold.QuantSold = (itemSold.QuantSold + AMTSold);

            await _dbConnection.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
