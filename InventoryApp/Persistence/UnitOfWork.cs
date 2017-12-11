using InventoryApp.Core;
using InventoryApp.Core.Models;
using InventoryApp.Core.Repositories;
using InventoryApp.Persistence.Repositories;

namespace InventoryApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IItemRepository Items { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Items = new ItemRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}