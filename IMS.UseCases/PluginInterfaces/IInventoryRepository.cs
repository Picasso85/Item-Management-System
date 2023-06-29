using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task UpdateInventoryAsync(InventoryItem inventory);
        Task<InventoryItem> GetInventoryByIdAsync(int inventoryId);
        Task<IEnumerable<InventoryItem>> GetInventoriesByNameAsync(string name);
        Task AddInventoryAsync(InventoryItem inventory);
        Task<IEnumerable<InventoryItem>> GetPageByNameAsync(string name, int currentPage);
        int GetMaxPageCount();

        int ItemsPerPage { get;}

         

        //Task<bool> ExistsAsync (Inventory inventory);
    }
}
