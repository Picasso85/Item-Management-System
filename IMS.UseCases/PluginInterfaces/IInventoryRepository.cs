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
        Task UpdateInventoryAsync(Inventory inventory);
        Task<Inventory> GetInventoryByIdAsync(int inventoryId);
        Task AddInventoryAsync(Inventory inventory);
        Task<IEnumerable<Inventory>> GetPageByNameAsync(string name, int currentPage);
        int GetMaxPageCount();
        int ItemsPerPage { get; }
        Task<IEnumerable<Inventory>> GetInventoryItemsAsync(string name);
        Task<IEnumerable<Inventory>> GetInventoryItemsAsync(string searchTerm, int page);
        IEnumerable<Inventory> GetPaginatedItems(IEnumerable<Inventory> items, int pageNumber);


        //Task<bool> ExistsAsync (Inventory inventory);
    }
}
