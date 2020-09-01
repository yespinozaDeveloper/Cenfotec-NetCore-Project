using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Models.Request
{
    public class CreateOrderDetailParam
    {
        [JsonPropertyName("order")]
        public long Order { get; set; }
        [JsonPropertyName("product")]
        public long Product { get; set; }
    }
}
