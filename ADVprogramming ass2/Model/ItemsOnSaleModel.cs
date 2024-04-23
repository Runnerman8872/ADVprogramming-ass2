//add-migration AddingItemModel
//update-database

using System.ComponentModel.DataAnnotations;
using ADVprogramming_ass2.Model;

namespace ADVprogramming_ass2.Model
{
    public class ItemsOnSaleModel
    {
        [Key]
        public int Item_Id { get; set; }

        [Required]
        [StringLength(75)]
        public string Item_Name { get; set; }

        [Required]
        [StringLength(75)]
        public string Item_Type { get; set; }

        [Required]
        [StringLength(75)]
        public string Supplier { get; set; }

        [Required]
        public int Amnt_left { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price_Pound { get; set; }
    }
}
