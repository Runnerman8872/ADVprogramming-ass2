﻿//add-migration AddingItemModel
//update-database

using System.ComponentModel.DataAnnotations;



namespace ADVprogramming_ass2.Model
{
    public class ItemsOnSaleModel
    {
        [Key]
        public Guid Item_Id { get; set; }

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
        public int Quantity { get; set; }

        public int QuantSold { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price_Pound { get; set; }

        [StringLength(750)]
        public string Item_description { get; set; }
    }
}
