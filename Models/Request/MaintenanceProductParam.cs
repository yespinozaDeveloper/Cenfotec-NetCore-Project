using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Models.Request
{
    public class MaintenanceProductParam
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("category")]
        public long Category { get; set; }
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
    }
}
