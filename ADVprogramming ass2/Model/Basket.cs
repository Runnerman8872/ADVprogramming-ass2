using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADVprogramming_ass2.Model
{
    public class Basket
    {
        [Key]
        public Guid Basket_Id { get; set; }

        [Required]
        public Guid Item_Id { get; set; }

        [ForeignKey ("Item_Id")]
        public ItemsOnSaleModel Item { get; set; }

        public int Quantity { get; set; } = 1;

        public Guid User_Id { get; set; }
    }
}
