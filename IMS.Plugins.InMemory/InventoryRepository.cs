using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<InventoryItem> _inventories;

        public int ItemsPerPage { get; private set; } = 10;

        public InventoryRepository()
        {
            _inventories = new List<InventoryItem>()
            {
                new InventoryItem { Id = 1, Name = "Laptop X-2343", Quantity = 12, Price = 999.99 },
                new InventoryItem { Id = 2, Name = "Laptop W-2301", Quantity = 8, Price = 1100.99 },
                new InventoryItem { Id = 3, Name = "Laptop K-2343", Quantity = 6, Price = 1200.99 },
                new InventoryItem { Id = 4, Name = "Laptop R-2343", Quantity = 4, Price = 1999.99 },
                new InventoryItem { Id = 5, Name = "Laptop X-3343", Quantity = 45, Price = 1299.99 },
                new InventoryItem { Id = 6, Name = "Laptop W-6501", Quantity = 3, Price = 1147.99 },
                new InventoryItem { Id = 7, Name = "Laptop K-6543", Quantity = 4, Price = 1298.99 },
                new InventoryItem { Id = 8, Name = "Laptop I-3343", Quantity = 15, Price = 1799.99 },
                new InventoryItem { Id = 9, Name = "Laptop I-6501", Quantity = 7, Price = 1647.99 },
                new InventoryItem { Id = 10, Name = "M/B-X4333", Quantity = 15, Price = 2298.99 },
                new InventoryItem { Id = 11, Name = "CPU I-30", Quantity = 6, Price = 579.99 },
                new InventoryItem { Id = 12, Name = "CPU I-29", Quantity = 8, Price = 479.99 },
                new InventoryItem { Id = 13, Name = "CPU X-400", Quantity = 7, Price = 879.99 },
                new InventoryItem { Id = 14, Name = "Case X-10", Quantity = 4, Price = 100.99 },
                new InventoryItem { Id = 15, Name = "Case X-21", Quantity = 20, Price = 129.99 },
                new InventoryItem { Id = 16, Name = "DDR10 450GB", Quantity = 68, Price = 129.99 },
                new InventoryItem { Id = 17, Name = "DDR12 600GB", Quantity = 50, Price = 159.99 },
                new InventoryItem { Id = 18, Name = "HDD 100TB", Quantity = 12, Price = 199.99 },
                new InventoryItem { Id = 19, Name = "RTX-7090Ti 100GB", Quantity = 12, Price = 799.99 },
                new InventoryItem { Id = 20, Name = "P-S 2000 Wat", Quantity = 46, Price = 159.99 },
                new InventoryItem { Id = 21, Name = "Laptop X-2343", Quantity = 12, Price = 999.99 },
                new InventoryItem { Id = 22, Name = "Laptop W-2301", Quantity = 8, Price = 1100.99 },
                new InventoryItem { Id = 23, Name = "Laptop K-2343", Quantity = 6, Price = 1200.99 },
                new InventoryItem { Id = 24, Name = "Laptop R-2343", Quantity = 4, Price = 1999.99 },
                new InventoryItem { Id = 25, Name = "Laptop X-3343", Quantity = 45, Price = 1299.99 },
                new InventoryItem { Id = 26, Name = "Laptop W-6501", Quantity = 3, Price = 1147.99 },
                new InventoryItem { Id = 27, Name = "Laptop K-6543", Quantity = 4, Price = 1298.99 },
                new InventoryItem { Id = 28, Name = "Laptop I-3343", Quantity = 15, Price = 1799.99 },
                new InventoryItem { Id = 29, Name = "Laptop I-6501", Quantity = 7, Price = 1647.99 },
                new InventoryItem { Id = 30, Name = "M/B-X4333", Quantity = 15, Price = 2298.99 },
                new InventoryItem { Id = 31, Name = "CPU I-30", Quantity = 6, Price = 579.99 },
                new InventoryItem { Id = 32, Name = "CPU I-29", Quantity = 8, Price = 479.99 },
                new InventoryItem { Id = 33, Name = "CPU X-400", Quantity = 7, Price = 879.99 },
                new InventoryItem { Id = 34, Name = "Case X-10", Quantity = 4, Price = 100.99 },
                new InventoryItem { Id = 35, Name = "Case X-21", Quantity = 20, Price = 129.99 },
                new InventoryItem { Id = 36, Name = "DDR10 450GB", Quantity = 68, Price = 129.99 },
                new InventoryItem { Id = 37, Name = "DDR12 600GB", Quantity = 50, Price = 159.99 },
                new InventoryItem { Id = 38, Name = "HDD 100TB", Quantity = 12, Price = 199.99 },
                new InventoryItem { Id = 39, Name = "RTX-7090Ti 100GB", Quantity = 12, Price = 799.99 },
                new InventoryItem { Id = 40, Name = "P-S 2000 Wat", Quantity = 46, Price = 159.99 }
            };

        }

        public Task AddInventoryAsync(InventoryItem inventory)
        {
            if (_inventories.Any(x => x.Name.Equals(inventory.Name, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _inventories.Max(x => x.Id);
            inventory.Id = maxId + 1;

            _inventories.Add(inventory);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<InventoryItem>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<InventoryItem> GetInventoryByIdAsync(int inventoryId)
        {
            var inv = _inventories.First(x => x.Id == inventoryId);
            var newInv = new InventoryItem
            {
                Id = inv.Id,
                Name = inv.Name,
                Price = inv.Price,
                Quantity = inv.Quantity
            };

            return await Task.FromResult(newInv);
        }

        public Task UpdateInventoryAsync(InventoryItem inventory)
        {
            if (_inventories.Any(x => x.Id != inventory.Id &&
                x.Name.Equals(inventory.Name, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var inv = _inventories.FirstOrDefault(x => x.Id == inventory.Id);
            if (inv != null)
            {
                inv.Name = inventory.Name;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<InventoryItem>> GetPageByNameAsync(string name, int page = 0)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                var paginatedInventories = _inventories
                    .Skip((page) * ItemsPerPage)
                    .Take(ItemsPerPage);

                return await Task.FromResult(paginatedInventories);
            }
            else
            {
                var paginatedInventories = _inventories
                    .Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .Skip((page) * ItemsPerPage)
                    .Take(ItemsPerPage);

                return await Task.FromResult(paginatedInventories);
            }
        }

        public int GetMaxPageCount()
        {
            return _inventories.Count / ItemsPerPage;
        }
    }
}