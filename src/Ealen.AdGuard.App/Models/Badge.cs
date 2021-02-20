using System;
using System.Text.Json.Serialization;

namespace Ealen.AdGuard.App.Models
{
    internal class Badge
    {
        [JsonPropertyName("schemaVersion")]
        public int SchemaVersion { get; }
        [JsonPropertyName("label")]
        public string Label { get; }
        [JsonPropertyName("message")]
        public string Message { get; }
        [JsonPropertyName("color")]
        public string Color { get; }

        public Badge(string label, string message, string color)
        {
            SchemaVersion = 1;
            Label = label ?? throw new ArgumentNullException(nameof(label));
            Message = message ?? throw new ArgumentNullException(nameof(message));
            Color = color ?? throw new ArgumentNullException(nameof(color));
        }
    }
}