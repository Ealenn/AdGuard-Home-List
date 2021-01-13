using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Ealen.AdGuard.App.Services.Abstractions
{
    public interface IAdGuardListService
    {
        HashSet<string> AllowList { get; }
        HashSet<string> BlockList { get; }

        Task<IAdGuardListService> FromFilesAsync(string path, string pattern, FileProviderFormat inputFormat, FileProviderType inputType);
        Task<IAdGuardListService> FromFileAsync(Stream stream, FileProviderFormat inputFormat, FileProviderType inputType);
        Task<IAdGuardListService> FromFileListWebAsync(Stream stream, FileProviderFormat inputFormat, FileProviderType inputType);
        Task<IAdGuardListService> FromWebAsync(string url, FileProviderFormat inputFormat, FileProviderType inputType);
        string FileLineTransform(string line, FileProviderFormat inputFormat, FileProviderType inputType);
    }
}
