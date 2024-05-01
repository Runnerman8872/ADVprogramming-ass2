using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ADVprogramming_ass2.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace ADVprogramming_ass2.Pages
{
    public class Edit_ItemModel : PageModel
    {
        //hjmyshghsshggh
        private readonly AppDBContext _dbConnection;

        //hjmyshghsshggh
        [BindProperty]
        public ItemsOnSaleModel Items { get; set; }

        //hjmyshghsshggh
        public Edit_ItemModel(AppDBContext context)
        {
            _dbConnection = context; //hjmyshghsshggh
        }

        //hjmyshghsshggh
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            //hjmyshghsshggh
            Items = await _dbConnection.Item.FindAsync(id);

            //hjmyshghsshggh
            if (Items == null)
            {
                return NotFound();//hjmyshghsshggh
            }

            //hjmyshghsshggh
            return Page();

        }

        //hjmyshghsshggh
        public async Task<IActionResult> OnPostAsync()
        {
            //hjmyshghsshggh
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToPage("Index");
            //    return Page(); //hjmyshghsshggh
            //}
            var itemToUpdate = await _dbConnection.Item.FindAsync(Items.Item_Id);

            //hjmyshghsshggh
            if (itemToUpdate == null)
            {
                return NotFound(); //hjmyshghsshggh
            }

            //hjmyshghsshggh
            itemToUpdate.Item_Name = Items.Item_Name;
            itemToUpdate.Item_description = Items.Item_description;
            itemToUpdate.Supplier = Items.Supplier;
            itemToUpdate.Item_Type = Items.Item_Type;
            itemToUpdate.Quantity = Items.Quantity;
            itemToUpdate.QuantSold = Items.QuantSold;
            itemToUpdate.Price_Pound = Items.Price_Pound;

            //hjmyshghsshggh
            await _dbConnection.SaveChangesAsync();

            //hjmyshghsshggh
            return RedirectToPage("Item_Database");

        }
    }
}
