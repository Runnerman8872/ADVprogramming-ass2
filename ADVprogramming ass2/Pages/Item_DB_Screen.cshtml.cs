using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ADVprogramming_ass2.Model;

namespace ADVprogramming_ass2.Pages
{
    public class Item_DB_ScreenModel : PageModel
    {
        private readonly AppDBContext _dbConnection;

        public ItemsOnSaleModel NewItem { get; set; }

        public Item_DB_ScreenModel(AppDBContext context)
        {
            _dbConnection = context;
        }

        public void OnGet()
        {
            NewItem = new ItemsOnSaleModel();
        }
        public IActionResult OnPost(ItemsOnSaleModel NewItem)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbConnection.Item.Add(NewItem);
            _dbConnection.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
