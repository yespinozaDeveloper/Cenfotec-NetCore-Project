using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Models.Request
{
    public class MaintenanceProductReviewParam
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("detail")]
        public string Detail { get; set; }
        [JsonPropertyName("user")]
        public long User { get; set; }
        [JsonPropertyName("product")]
        public long Product { get; set; }
    }
}
