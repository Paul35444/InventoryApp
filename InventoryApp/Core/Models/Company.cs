using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Core.Models
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
        [StringLength(30)]
        public string ContactNumber { get; set; }

        [Required]
        public string ContactEmail { get; set; }
    }
}