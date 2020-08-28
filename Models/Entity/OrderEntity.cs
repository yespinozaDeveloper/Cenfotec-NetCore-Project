using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models.Entity
{
    public class OrderEntity
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("user")]
        public string User { get; set; }
        [JsonPropertyName("products")]
        public List<ProductEntity> Products { get; set; }
    }
}
