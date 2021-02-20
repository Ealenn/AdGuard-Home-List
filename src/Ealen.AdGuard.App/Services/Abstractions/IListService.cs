using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ealen.AdGuard.App.Services.Abstractions
{
    public interface IListService
    {
        Task StoreListAsync(string filePath, HashSet<string> list);
        Task PurgeListAsync(string filePath);
        Task GenerateBadgeAsync(string filePath, int elements, string label, string color);
    }
}
