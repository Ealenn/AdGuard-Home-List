using Ealen.AdGuard.App.Services;
using Ealen.AdGuard.App.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace Ealen.AdGuard.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .AddSingleton<IAdGuardListService, AdGuardListService>()
                .AddSingleton<IListService, ListService>()
                .BuildServiceProvider();

            // Args
            string path = Path.GetFullPath(Directory.GetCurrentDirectory().Split("src")[0]);

            // Services
            var adGuardListService = serviceProvider.GetService<IAdGuardListService>();

            // Custom
            await adGuardListService.FromFilesAsync(Path.Combine(path, "allowlist", "custom"), "*.txt", FileProviderFormat.AD_GUARD, FileProviderType.ALLOW_LIST);
            await adGuardListService.FromFilesAsync(Path.Combine(path, "blocklist", "custom"), "*.txt", FileProviderFormat.AD_GUARD, FileProviderType.BLOCK_LIST);

            // External - AllowList
            await adGuardListService
                .FromFileListWebAsync(new StreamReader(Path.Combine(path, "allowlist", "external", "allowlist.external.adguard.list")).BaseStream, FileProviderFormat.AD_GUARD, FileProviderType.ALLOW_LIST);
            await adGuardListService
                .FromFileListWebAsync(new StreamReader(Path.Combine(path, "allowlist", "external", "allowlist.external.hosts.list")).BaseStream, FileProviderFormat.HOSTS, FileProviderType.ALLOW_LIST);
            await adGuardListService
                .FromFileListWebAsync(new StreamReader(Path.Combine(path, "allowlist", "external", "allowlist.external.pihole.list")).BaseStream, FileProviderFormat.PI_HOLE, FileProviderType.ALLOW_LIST);

            // External - BlockList
            await adGuardListService
                .FromFileListWebAsync(new StreamReader(Path.Combine(path, "blocklist", "external", "blocklist.external.adguard.list")).BaseStream, FileProviderFormat.AD_GUARD, FileProviderType.BLOCK_LIST);
            await adGuardListService
                .FromFileListWebAsync(new StreamReader(Path.Combine(path, "blocklist", "external", "blocklist.external.hosts.list")).BaseStream, FileProviderFormat.HOSTS, FileProviderType.BLOCK_LIST);
            await adGuardListService
                .FromFileListWebAsync(new StreamReader(Path.Combine(path, "blocklist", "external", "blocklist.external.pihole.list")).BaseStream, FileProviderFormat.PI_HOLE, FileProviderType.BLOCK_LIST);

            // Save Lists
            var listService = serviceProvider.GetService<IListService>();
            await listService.PurgeListAsync(Path.Combine(path, "public", "AdGuard-Home-List.Allow.txt"));
            await listService.StoreListAsync(Path.Combine(path, "public", "AdGuard-Home-List.Allow.txt"), adGuardListService.AllowList);

            await listService.PurgeListAsync(Path.Combine(path, "public", "AdGuard-Home-List.Block.txt"));
            await listService.StoreListAsync(Path.Combine(path, "public", "AdGuard-Home-List.Block.txt"), adGuardListService.BlockList);
        }
    }
}
