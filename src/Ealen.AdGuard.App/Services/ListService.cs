using Ealen.AdGuard.App.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Ealen.AdGuard.App.Services
{
    public class ListService : IListService
    {
        private readonly ILogger<ListService> _logger;

        public ListService(ILogger<ListService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task PurgeListAsync(string filePath)
        {
            EnsureDirectory(filePath);
            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            await stream.FlushAsync();

            _logger.LogInformation($"{filePath} was now empty");
        }

        public async Task StoreListAsync(string filePath, HashSet<string> list)
        {
            EnsureDirectory(filePath);
            using var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            using var stream = new StreamWriter(fileStream);
            foreach (var element in list)
            {
                await stream.WriteLineAsync(element);
            }

            _logger.LogInformation($"{list.Count} element(s) added to list {filePath}");
        }

        private void EnsureDirectory(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(filePath.Replace(Path.GetFileName(filePath), ""));
                File.Create(filePath).Close();
            }
        }
    }
}
