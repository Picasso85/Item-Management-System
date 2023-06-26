using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository() 
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, InventoryName = "Laptop X-2343", Quantity = 12, Price = 999.99 },
                new Inventory { InventoryId = 2, InventoryName = "Laptop W-2301", Quantity = 8, Price = 1100.99 },
                new Inventory { InventoryId = 3, InventoryName = "Laptop K-2343", Quantity = 6, Price = 1200.99 },
                new Inventory { InventoryId = 4, InventoryName = "Laptop R-2343", Quantity = 4, Price = 1999.99 },
                new Inventory { InventoryId = 5, InventoryName = "Laptop X-3343", Quantity = 45, Price = 1299.99 },
                new Inventory { InventoryId = 6, InventoryName = "Laptop W-6501", Quantity = 3, Price = 1147.99 },
                new Inventory { InventoryId = 7, InventoryName = "Laptop K-6543", Quantity = 4, Price = 1298.99 },
                new Inventory { InventoryId = 8, InventoryName = "Laptop I-3343", Quantity = 15, Price = 1799.99 },
                new Inventory { InventoryId = 9, InventoryName = "Laptop I-6501", Quantity = 7, Price = 1647.99 },
                new Inventory { InventoryId = 10, InventoryName = "Laptop I-6543", Quantity = 2, Price = 2298.99 }
            };
        
        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId + 1;

            _inventories.Add(inventory);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
        {
            var inv = _inventories.First(x => x.InventoryId == inventoryId);
            var newInv = new Inventory
            {
                InventoryId = inv.InventoryId,
                InventoryName = inv.InventoryName,
                Price = inv.Price,
                Quantity = inv.Quantity
            };

            return await Task.FromResult(newInv);
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryId != inventory.InventoryId &&
                x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var inv = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
            }

            return Task.CompletedTask;
        }
    }
}