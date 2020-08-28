using System.Text.Json.Serialization;

namespace Models.Entity
{
    public class UserEntity
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("personalIdentification")]
        public string PersonalIdentification { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
    }
}
