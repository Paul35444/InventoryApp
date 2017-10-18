using InventoryApp.Models;

namespace InventoryApp.ViewModels
{
    public class ItemFormViewModel
    {
        public ApplicationUser User { get; set; }
        public byte Company { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }
    }
}