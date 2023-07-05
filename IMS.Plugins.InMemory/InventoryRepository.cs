using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public int ItemsPerPage { get; private set; } = 10;
        
        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, Type = "Case", InventoryName = "Case S-49", Quantity = 12, Price = 129.99 },
                new Inventory { InventoryId = 2, Type = "Motherboard", InventoryName = "M/B-X1333", Quantity = 8, Price = 110.99 },
                new Inventory { InventoryId = 3, Type = "Motherboard", InventoryName = "M/B-X1533", Quantity = 6, Price = 120.99 },
                new Inventory { InventoryId = 4, Type = "Motherboard", InventoryName = "M/B-X1933", Quantity = 4, Price = 199.99 },
                new Inventory { InventoryId = 5, Type = "Motherboard", InventoryName = "M/B-X2533", Quantity = 45, Price = 129.99 },
                new Inventory { InventoryId = 6, Type = "Motherboard", InventoryName = "M/B-X2733", Quantity = 3, Price = 114.99 },
                new Inventory { InventoryId = 7, Type = "Motherboard", InventoryName = "M/B-X3033", Quantity = 4, Price = 129.99 },
                new Inventory { InventoryId = 8, Type = "Motherboard", InventoryName = "M/B-X3133", Quantity = 15, Price = 179.99 },
                new Inventory { InventoryId = 9, Type = "Motherboard", InventoryName = "M/B-X3233", Quantity = 7, Price = 164.99 },
                new Inventory { InventoryId = 10, Type = "Motherboard", InventoryName = "M/B-X4333", Quantity = 15, Price = 229.99 },
                new Inventory { InventoryId = 11, Type = "CPU", InventoryName = "CPU I-30", Quantity = 6, Price = 579.99 },
                new Inventory { InventoryId = 12, Type = "CPU", InventoryName = "CPU I-29", Quantity = 8, Price = 479.99 },
                new Inventory { InventoryId = 13, Type = "CPU", InventoryName = "CPU X-400", Quantity = 7, Price = 879.99 },
                new Inventory { InventoryId = 14, Type = "Case", InventoryName = "Case X-10", Quantity = 4, Price = 100.99 },
                new Inventory { InventoryId = 15, Type = "Case", InventoryName = "Case X-21", Quantity = 20, Price = 129.99 },
                new Inventory { InventoryId = 16, Type = "Memmory", InventoryName = "DDR10 450GB", Quantity = 68, Price = 129.99 },
                new Inventory { InventoryId = 17, Type = "Memmory", InventoryName = "DDR12 600GB", Quantity = 50, Price = 159.99 },
                new Inventory { InventoryId = 18, Type = "SSD", InventoryName = "SSD 150TB", Quantity = 12, Price = 199.99 },
                new Inventory { InventoryId = 19, Type = "Graphic Card", InventoryName = "RTX-7090Ti 100GB", Quantity = 12, Price = 899.99 },
                new Inventory { InventoryId = 20, Type = "Power Supply", InventoryName = "P-S 2000 Wat", Quantity = 46, Price = 159.99 },
                new Inventory { InventoryId = 21, Type = "Power Supply", InventoryName = "P-S 2200 Wat", Quantity = 12, Price = 199.99 },
                new Inventory { InventoryId = 22, Type = "Power Supply", InventoryName = "P-S 2500 Wat", Quantity = 8, Price = 210.99 },
                new Inventory { InventoryId = 23, Type = "SSD", InventoryName = "SSD 100TB", Quantity = 6, Price = 60.99 },
                new Inventory { InventoryId = 24, Type = "SSD", InventoryName = "SSD 200TB", Quantity = 4, Price = 111.99 },
                new Inventory { InventoryId = 25, Type = "SSD", InventoryName = "SSD 2500TB", Quantity = 45, Price = 169.99 },
                new Inventory { InventoryId = 26, Type = "SSD", InventoryName = "SSD 300TB", Quantity = 3, Price = 174.99 },
                new Inventory { InventoryId = 27, Type = "SSD", InventoryName = "SSD 3500TB", Quantity = 4, Price = 189.99 },
                new Inventory { InventoryId = 28, Type = "Graphic Card", InventoryName = "RTX-5090Ti 80GB", Quantity = 15, Price = 579.99 },
                new Inventory { InventoryId = 29, Type = "Graphic Card", InventoryName = "RTX-5090Ti 90GB", Quantity = 7, Price = 664.99 },
                new Inventory { InventoryId = 30, Type = "Motherboard", InventoryName = "M/B-X4344", Quantity = 15, Price = 229.99 },
                new Inventory { InventoryId = 31, Type = "CPU", InventoryName = "CPU Z-30", Quantity = 6, Price = 579.99 },
                new Inventory { InventoryId = 32, Type = "CPU", InventoryName = "CPU Z-29", Quantity = 8, Price = 479.99 },
                new Inventory { InventoryId = 33, Type = "CPU", InventoryName = "CPU K-410", Quantity = 7, Price = 879.99 },
                new Inventory { InventoryId = 34, Type = "Case", InventoryName = "Case X-14", Quantity = 4, Price = 100.99 },
                new Inventory { InventoryId = 35, Type = "Case", InventoryName = "Case X-26", Quantity = 20, Price = 129.99 },
                new Inventory { InventoryId = 36, Type = "Memmory", InventoryName = "DDR10 350GB", Quantity = 68, Price = 129.99 },
                new Inventory { InventoryId = 37, Type = "Memmory", InventoryName = "DDR12 200GB", Quantity = 50, Price = 159.99 },
                new Inventory { InventoryId = 38, Type = "SSD", InventoryName = "SSD 400TB", Quantity = 12, Price = 199.99 },
                new Inventory { InventoryId = 39, Type = "Graphic Card", InventoryName = "RTX-6090Ti 100GB", Quantity = 12, Price = 799.99 },
                new Inventory { InventoryId = 40, Type = "Power Supply", InventoryName = "P-S 2500 Wat", Quantity = 46, Price = 159.99 }
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

        public async Task<IEnumerable<Inventory>> GetPageByNameAsync(string name, int page = 0)
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
                    .Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .Skip((page) * ItemsPerPage)
                    .Take(ItemsPerPage);

                return await Task.FromResult(paginatedInventories);
            }
        }

        public int GetMaxPageCount()
        {
            return _inventories.Count / ItemsPerPage;
        }

        public class Pagination
        {
            public int ItemsPerPage { get; private set; } = 10;

            public void SetItemsPerPage(int value)
            {
                ItemsPerPage = value;
            }
        }

        //public int getmaxpagecount(string searchquery = "")
        //{
        //    int maxpages = getmaxpagecount();
        //    if (string.isnullorwhitespace(searchquery))
        //    {
        //        return _inventories.count / itemsperpage;
        //    }
        //    else
        //    {
        //        int matchingitemcount = _inventories.count(inventory => inventory.contains(searchquery));
        //        return matchingitemcount / itemsperpage;
        //    }
        //}
    }
}