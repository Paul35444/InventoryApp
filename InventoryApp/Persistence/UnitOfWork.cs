using InventoryApp.Models;
using InventoryApp.Repositories;

namespace InventoryApp.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository Items { get; private set; }

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