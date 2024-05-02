using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADVprogramming_ass2.Model;

namespace ADVprogramming_ass2.Pages
{
    public class BasketsModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public BasketsModel(AppDBContext db)
        {
            _dbContext = db;
        }

        public List<BasketProductViewModel> BasketItems { get; set; }

        public class BasketProductViewModel
        {
            public Guid BasketId { get; set; }
            public int Quantity { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
        }

        public async Task OnGetAsync()
        {
            string userId = HttpContext.Session.GetString("UserId");

                //Guid.Parse(ItemId.ToString())
            if (!string.IsNullOrEmpty(userId))
            {
                var UIDtoGuid = Guid.Parse(userId.ToString());
                BasketItems = await _dbContext.Baskets
                    .Where(b => b.User_Id == UIDtoGuid)
                    .Select(b => new BasketProductViewModel
                    {
                        BasketId = b.Basket_Id,
                        Quantity = b.Quantity,
                        ProductName = b.Item.Item_Name,
                        Description = b.Item.Item_description
                    })
                    .ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            string userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToPage("/Login");
            }
            var UserIdGuid = Guid.Parse(userId.ToString());
            var basketItems = await _dbContext.Baskets.Where(b => b.User_Id == UserIdGuid).ToListAsync();
            if (!basketItems.Any())
            {
                return Page();
            }

            var order = new Order { User_Id = UserIdGuid };
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            foreach(var item in basketItems)
            {
                var orderItem = new Order_Item
                {
                    Order_Id = order.Order_Id,
                    Item_Id = item.Item_Id,
                    Quantity = item.Quantity
                };
                _dbContext.OrderItems.Add(orderItem);

                _dbContext.Baskets.Remove(item);
            }
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/Shop_Page", new { orderId = order.Order_Id});
        }

    }
}
