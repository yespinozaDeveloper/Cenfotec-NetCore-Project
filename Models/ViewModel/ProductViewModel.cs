using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Models.ViewModel
{
    public class ProductViewModel
    {
        public List<ProductEntity> ProductList { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public string SelectedCategoryId { get; set; }

        public string ProductSearchValue { get; set; }
        public int ColumnsByRow { get; set; }

        public ProductViewModel()
        {
            ProductList = new List<ProductEntity>();
            CategoryList = new SelectList(new List<SelectListItem>() { new SelectListItem { Value = "-1", Text = "All" } }, "Value", "Text");
            ColumnsByRow = 5;
        }

        public ProductViewModel(List<CategoryEntity> categories)
        {
            ProductList = new List<ProductEntity>();
            ColumnsByRow = 5;
            categories.Insert(0, new CategoryEntity { Id = -1, Name = "All" });
            setCategoryList(categories);
        }

        public void setCategoryList(List<CategoryEntity> categories)
        {
            categories.Insert(0, new CategoryEntity { Id = -1, Name = "All" });
            CategoryList = new SelectList(categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList(), "Value", "Text");
        }
    }
}
