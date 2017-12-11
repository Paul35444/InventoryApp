using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using InventoryApp.Core.Models;
using InventoryApp.Core.Repositories;

namespace InventoryApp.Persistence.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Item GetAllItems(int itemId)
        {
            return _context.Items.SingleOrDefault(i => i.Id == itemId);
        }

        public IEnumerable<Item> MyInventory(string userId)
        {
            //var userId = User.Identity.GetUserId();
            //var items = _context.Items

            return _context.Items
                .Where(i => i.UserId == userId && !i.IsDeleted)
                .Include(i => i.Company)
                .ToList();

        }

        public void Add(Item item)
        {
            _context.Items.Add(item);
        }
    }
}