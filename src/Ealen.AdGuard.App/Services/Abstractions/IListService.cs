using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ealen.AdGuard.App.Services.Abstractions
{
    public interface IListService
    {
        Task StoreListAsync(string filePath, HashSet<string> list);
        Task PurgeListAsync(string filePath);
    }
}
