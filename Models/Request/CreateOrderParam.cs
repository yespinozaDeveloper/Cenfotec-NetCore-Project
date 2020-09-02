using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Models.Request
{
    public class CreateOrderParam
    {
        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}
