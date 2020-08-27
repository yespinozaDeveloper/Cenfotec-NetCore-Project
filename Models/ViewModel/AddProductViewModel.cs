using Models.Entity;
using System.Collections.Generic;

namespace Models.ViewModel
{
    public class AddProductViewModel
    {
        public ProductEntity Product { get; set; }
        public List<CategoryEntity> CategoryList { get; set; }

        public AddProductViewModel()
        {
            CategoryList = new List<CategoryEntity>();
        }
    }
}
