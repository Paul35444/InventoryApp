using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Core.Models
{
    public class Item
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }


        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public int Cost { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Company { get; set; }

        //public string CompanyId { get; set; }
    }
}