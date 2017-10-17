using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Models
{
    public class Company
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactNumber { get; set; }
    }
}