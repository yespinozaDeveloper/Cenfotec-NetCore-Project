using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Models.ViewModel
{
    public class ProductViewModel
    {
        public ProductEntity Product { get; set; }

        public List<ReviewEntity> Reviews { get; set; }

        public string Comment { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public ProductViewModel()
        {
            Product = new ProductEntity();
            Reviews = new List<ReviewEntity>();
        }

        public ProductViewModel(ProductEntity product)
        {
            Product = product;
            Reviews = new List<ReviewEntity>();
        }
    }
}
