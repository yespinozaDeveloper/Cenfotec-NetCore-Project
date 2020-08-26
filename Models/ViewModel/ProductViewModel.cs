using Models.Entity;
using System.Collections.Generic;

namespace Models.ViewModel
{
    public class ProductViewModel
    {
        public List<ProductEntity> ProductList { get; set; }
        public List<CategoryEntity> CategoryList { get; set; }
        public int ColumnsByRow { get; set; }

        public ProductViewModel()
        {
            ProductList = new List<ProductEntity>();
            CategoryList = new List<CategoryEntity>();
            ColumnsByRow = 5;
        }
    }
}
