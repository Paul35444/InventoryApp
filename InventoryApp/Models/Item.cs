using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Models
{
    public class Item
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        //public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public int Cost { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        public string Company { get; set; }

        [Required]
        public byte CompanyId { get; set; }
    }
}