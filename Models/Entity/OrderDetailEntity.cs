using System;
using System.Text.Json.Serialization;

namespace Models.Entity
{
    public class OrderDetailEntity
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("order")]
        public long Order { get; set; }

        [JsonPropertyName("product")]
        public ProductEntity Product { get; set; }
    }
}
