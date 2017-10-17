using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public string Cost { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        [Required]
        public Company Company { get; set; }
    }
}