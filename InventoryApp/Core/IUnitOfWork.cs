using InventoryApp.Core.Repositories;

namespace InventoryApp.Core
{
    public interface IUnitOfWork
    {
        IItemRepository Items { get; }
        void Complete();
    }
}