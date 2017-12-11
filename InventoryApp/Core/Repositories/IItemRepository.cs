using System.Collections.Generic;
using InventoryApp.Core.Models;

namespace InventoryApp.Core.Repositories
{
    public interface IItemRepository
    {
        Item GetAllItems(int itemId);
        IEnumerable<Item> MyInventory(string userId);
        void Add(Item item);
    }
}