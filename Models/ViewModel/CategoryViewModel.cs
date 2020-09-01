using Models.Entity;
using System.Collections.Generic;

namespace Models.ViewModel
{
    public class CategoryViewModel
    {
        public List<CategoryEntity> CategoryList { get; set; }

        public CategoryViewModel()
        {
            CategoryList = new List<CategoryEntity>();
        }
    }
}
