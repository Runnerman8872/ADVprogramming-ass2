using System.ComponentModel.DataAnnotations;

namespace ADVprogramming_ass2.Model
{
    public class Order
    {
        [Key]
        public Guid Order_Id { get; set; }

        [Required]
        public Guid User_Id { get; set; }

        public DateTime Order_Date { get; set; } = DateTime.Now;

        public virtual List<Order_Item> Items { get; set; } = new List<Order_Item>();

        public int Order_Total { get; set; }
    }
}
