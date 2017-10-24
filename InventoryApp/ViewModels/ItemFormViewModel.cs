using InventoryApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryApp.ViewModels
{
    public class ItemFormViewModel
    {
        //[Required]
        public ApplicationUser User { get; set; }

        //[Required]
        public string UserId { get; set; }

        [Required]
        public string Company { get; set; }

        //public string CompanyId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Cost { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}