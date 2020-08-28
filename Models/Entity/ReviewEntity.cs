﻿using System.Text.Json.Serialization;

namespace Models.Entity
{
    public class ReviewEntity
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("category")]
        public CategoryEntity Category { get; set; }
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
    }
}
