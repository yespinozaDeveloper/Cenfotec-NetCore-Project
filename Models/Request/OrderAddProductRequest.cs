using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request
{
    public class OrderAddProductRequest
    {
        public long order { get; set; }
        public long product { get; set; }
    }
}
