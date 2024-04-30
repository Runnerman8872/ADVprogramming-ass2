using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ADVprogramming_ass2.Model;
using System.Threading.Tasks;
using System.Linq;

namespace ADVprogramming_ass2.Pages
{
    public class Delete_ItemModel : PageModel
    {
        private readonly AppDBContext _dbConnection;

        public ItemsOnSaleModel Items { get; set; }
        public UserModel Users { get; set; }

        public Delete_ItemModel(AppDBContext context)
        {
            _dbConnection = context;
        }

        public void OnGet(Guid id)
        {
            Items = _dbConnection.Item.FirstOrDefault(t => t.Item_Id == id);
        
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var itemToDelete = _dbConnection.Item.FirstOrDefault(t => t.Item_Id == id);

            if (itemToDelete != null)
            {
                _dbConnection.Item.Remove(itemToDelete);

                await _dbConnection.SaveChangesAsync();

                return RedirectToPage("Item_Database");
            }
            else
            {
                return NotFound();
            }
        }

    }
}
