namespace InventoryApp.Core.Models
{
    public class Item
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }

        public int Cost { get; set; }

        public int Quantity { get; set; }

        public string Company { get; set; }

        //public string CompanyId { get; set; }
    }
}