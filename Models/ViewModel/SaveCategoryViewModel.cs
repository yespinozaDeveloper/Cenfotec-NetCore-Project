using Models.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.ViewModel
{
    public class SaveCategoryViewModel : BaseViewModel
    {
        public CategoryEntity Category { get; set; }

        public bool isLoading { get; set; }

        public SaveCategoryViewModel()
        {
            Category = new CategoryEntity();
        }
    }
}
