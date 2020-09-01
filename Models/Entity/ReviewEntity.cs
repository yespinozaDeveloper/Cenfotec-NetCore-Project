using System.Text.Json.Serialization;

namespace Models.Entity
{
    public class ReviewEntity
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("detail")]
        public string Detail { get; set; }
        [JsonPropertyName("product")]
        public ProductEntity Product { get; set; }
        [JsonPropertyName("user")]
        public UserEntity User { get; set; }
    }
}
