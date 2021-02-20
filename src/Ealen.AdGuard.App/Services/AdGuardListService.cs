using Ealen.AdGuard.App.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ealen.AdGuard.App.Services
{
    public class AdGuardListService : IAdGuardListService
    {
        private const bool DEBUG = false;
        public HashSet<string> AllowList { get; } = new HashSet<string>();
        public HashSet<string> BlockList { get; } = new HashSet<string>();

        private readonly ILogger<AdGuardListService> _logger;

        public AdGuardListService(ILogger<AdGuardListService> logger)
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public string FileLineTransform(string line, FileProviderFormat inputFormat, FileProviderType inputType)
        {
            var transformedLine = Regex.Replace(line, " {2,}", " ").Trim();
            
            if (transformedLine.StartsWith("#") || transformedLine.StartsWith("!"))
            {
                return string.Empty;
            }

            if (inputFormat.Equals(FileProviderFormat.AD_GUARD))
            {
                return transformedLine;
            }

            if (inputFormat.Equals(FileProviderFormat.HOSTS))
            {
                var host = transformedLine.Split(" ");
                if (host.Length != 2)
                {
                    return string.Empty;
                }
                transformedLine = host[1];
            }

            switch (inputType)
            {
                case FileProviderType.ALLOW_LIST:
                    return $"@@||{transformedLine}^$important";
                case FileProviderType.BLOCK_LIST:
                    return $"||{transformedLine}^";
            }

            return string.Empty;
        }

        public async Task<IAdGuardListService> FromFileAsync(Stream stream, FileProviderFormat inputFormat, FileProviderType inputType, string comment = "")
        {
            int currentElementInLists = AllowList.Count + BlockList.Count;
            using var fileStream = new StreamReader(stream);
            string currentLine;
            while ((currentLine = await fileStream.ReadLineAsync()) != null)
            {
                currentLine = FileLineTransform(currentLine, inputFormat, inputType);
                if (string.IsNullOrWhiteSpace(currentLine))
                {
                    continue;
                }

                switch (inputType)
                {
                    case FileProviderType.ALLOW_LIST:
                        AllowList.Add(currentLine + comment);
                        break;
                    case FileProviderType.BLOCK_LIST:
                        BlockList.Add(currentLine + comment);
                        break;
                }
            }

            _logger.LogInformation($"{AllowList.Count + BlockList.Count - currentElementInLists} element(s) added with file");
            return this;
        }

        public async Task<IAdGuardListService> FromFilesAsync(string path, string pattern, FileProviderFormat inputFormat, FileProviderType inputType)
        {
            string[] files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
            foreach (var file in files)
            {
                using var stream = new StreamReader(file);
                await FromFileAsync(
                    stream.BaseStream,
                    inputFormat,
                    inputType,
                    DEBUG ? $"#{file}" : string.Empty);
            }

            return this;
        }

        public async Task<IAdGuardListService> FromFileListWebAsync(Stream stream, FileProviderFormat inputFormat, FileProviderType inputType)
        {
            int currentElementInLists = AllowList.Count + BlockList.Count;
            using var fileStream = new StreamReader(stream);
            string currentLine;
            while ((currentLine = await fileStream.ReadLineAsync()) != null)
            {
                currentLine = currentLine.Trim();
                if (string.IsNullOrWhiteSpace(currentLine))
                {
                    continue;
                }

                await FromWebAsync(currentLine, inputFormat, inputType);
            }

            _logger.LogInformation($"{AllowList.Count + BlockList.Count - currentElementInLists} element(s) added with webfile");
            return this;
        }

        public async Task<IAdGuardListService> FromWebAsync(string url, FileProviderFormat inputFormat, FileProviderType inputType)
        {
            try
            {
                using WebClient client = new WebClient();
                using Stream stream = client.OpenRead(url);
                await FromFileAsync(
                    stream,
                    inputFormat,
                    inputType,
                    DEBUG ? $"#{url}" : string.Empty);
            } catch (WebException webException)
            {
                _logger.LogError($"Unable to dowload list in {url}", webException);
            }

            return this;
        }
    }
}
