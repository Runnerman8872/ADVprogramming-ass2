using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADVprogramming_ass2.Model
{
    public class Order_Item
    {
        [Key]
        public Guid Order_Item_Id { get; set; }

        [Required]
        public Guid Order_Id { get; set; }

        [ForeignKey ("Order_Id")]
        public Order Order { get; set; }

        [Required]
        public Guid Item_Id { get; set; }

        [ForeignKey("Item_Id")]
        public ItemsOnSaleModel Item { get; set; }

        public int Quantity { get; set; }
    }
}
