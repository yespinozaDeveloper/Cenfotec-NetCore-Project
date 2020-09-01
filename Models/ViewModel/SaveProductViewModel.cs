using Models.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.ViewModel
{
    public class SaveProductViewModel : BaseViewModel
    {
        public ProductEntity Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public string SelectedCategoryId { get; set; }

        public bool isLoading { get; set; }

        public SaveProductViewModel()
        {
            CategoryList = new SelectList(new List<SelectListItem>(), "Value", "Text");
        }

        public SaveProductViewModel(List<CategoryEntity> categories)
        {
            setCategoryList(categories);
        }

        public void setCategoryList(List<CategoryEntity> categories)
        {
            CategoryList = new SelectList(categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList(), "Value", "Text");
        }
    }
}
