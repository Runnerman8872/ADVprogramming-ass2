using ADVprogramming_ass2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ADVprogramming_ass2.Pages
{
    public class Shop_pageModel : PageModel

    {
        public ItemsOnSaleModel AddItem { get; set; }

        private readonly AppDBContext _dbConnection;

        public Shop_pageModel(AppDBContext db)
        {
            _dbConnection = db;
            //
            //
            //
        }

        private readonly ILogger<Shop_pageModel> _logger;

        public List<ItemsOnSaleModel> Items { get; set; } = new List<ItemsOnSaleModel>();

        [BindProperty]
        public ItemsOnSaleModel Product { get; set; }

        public async Task OnGetAsync()
        {
            Items = await _dbConnection.Item.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddProductAsync()
        {
            if (!ModelState.IsValid)
            {
                Items = await _dbConnection.Item.ToListAsync();
                return Page();
            }

            _dbConnection.Add(AddItem);
            await _dbConnection.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToBasketAsync(Guid ItemId)
        {
            //var userID = Guid.Parse(HttpContext.Session.GetString("UserId"));
            //var emptcheck = userID.ToString();

            var userId = HttpContext.Session.GetString("User_Name");
            var IdConvert = Guid.Parse(ItemId.ToString());
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToPage("/Login");
            }

            var item2str= ItemId.ToString();
            var productToAdd = await _dbConnection.Item.FindAsync(ItemId);
            if (productToAdd == null)
            {
                return NotFound();
            }

            var basketItem = new Basket { Item_Id = productToAdd.Item_Id, User_Id = IdConvert };
            _dbConnection.Baskets.Add(basketItem);
            await _dbConnection.SaveChangesAsync();

            return RedirectToPage();
        }



    }
}
