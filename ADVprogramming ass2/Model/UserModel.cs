//add-migration AddingItemModel
//update-database

using System.ComponentModel.DataAnnotations;
using ADVprogramming_ass2.Model;

namespace ADVprogramming_ass2.Model
{
    public class UserModel
    {
        [Key]
        public Guid User_Id { get; set; }

        [Required]
        [StringLength(75)]
        public string User_Name { get; set;}

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string User_Email { get; set;}

        [Required]
        public int Use_Age { get; set; }

        [Required]
        public bool Loyalty_Card { get; set; }

        [Required]
        public bool Staff_Member { get; set; }


    }
}
