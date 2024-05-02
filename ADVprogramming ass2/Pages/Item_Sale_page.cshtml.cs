using ADVprogramming_ass2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

namespace ADVprogramming_ass2.Pages
{
    public class Item_Sale_pageModel : PageModel
    {
        private readonly AppDBContext _dbConnection;


        public Item_Sale_pageModel(AppDBContext context)
        {
            _dbConnection = context;
        }

        public ItemsOnSaleModel AddItem { get; set; }

        [BindProperty]
        public ItemsOnSaleModel Product { get; set; }

        public List<ItemsOnSaleModel> Items { get; set; } = new List<ItemsOnSaleModel>();

        public async Task OnGetAsync()
        {
            Items = await _dbConnection.Item.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddProductAsync()
        {
            //hjmyshghsshggh
            if (!ModelState.IsValid)
            {
                Items = await _dbConnection.Item.ToListAsync();
                return Page();//hjmyshghsshggh
            }

            _dbConnection.Add(AddItem);
            await _dbConnection.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToBasketAsync(Guid ItemId)
        {
            var userID = Guid.Parse(HttpContext.Session.GetString("UserId"));
            var emptcheck = userID.ToString();
            if (string.IsNullOrEmpty(emptcheck))//string.IsNullOrEmpty(userID))
            {
                return RedirectToPage("/Login");
            }

            var item2str = ItemId.ToString();
            var productToAdd = await _dbConnection.Item.FindAsync(ItemId);
            if (productToAdd == null)
            {
                return NotFound();
            }

            var basketItem = new Basket { Item_Id = productToAdd.Item_Id, User_Id = userID };
            _dbConnection.Baskets.Add(basketItem);
            await _dbConnection.SaveChangesAsync();
            return RedirectToPage();
        }

    }
}
