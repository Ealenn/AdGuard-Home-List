using Ealen.AdGuard.App.Models;
using Ealen.AdGuard.App.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
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
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            Directory.CreateDirectory(filePath.Replace(Path.GetFileName(filePath), ""));
            File.Create(filePath).Close();
        }
        public async Task GenerateBadgeAsync(string filePath, int elements, string label, string color)
        {
            EnsureDirectory(filePath);

            var numberFormat = new CultureInfo("en-US", false).NumberFormat;
            numberFormat.CurrencySymbol = string.Empty;
            numberFormat.CurrencyDecimalDigits = 0;
            var badge = new Badge(
                label,
                elements.ToString("c", numberFormat),
                color);

            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            using var streamWriter = new StreamWriter(stream);
            await streamWriter.WriteAsync(JsonSerializer.Serialize(badge));
        }
    }
}
