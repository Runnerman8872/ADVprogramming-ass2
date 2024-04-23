//add-migration AddingItemModel
//update-database

using System.ComponentModel.DataAnnotations;

namespace ADVprogramming_ass2.Model
{
    public class ItemsOnSaleModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Item_Type { get; set; }
        public string Supplier { get; set; }
        public int Amnt_left { get; set; }
        public float Price_Pound { get; set; }
    }
}
