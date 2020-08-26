using System.Text.Json.Serialization;


namespace Models.Entity
{
    public class CategoryEntity
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
