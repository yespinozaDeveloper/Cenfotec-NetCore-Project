using Models.Entity;
using System.Collections.Generic;

namespace Models.ViewModel
{
    public class ShoppingCarViewModel : BaseViewModel
    {
        public List<ProductEntity> ProductList { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public ShoppingCarViewModel()
        {
            ProductList = new List<ProductEntity>();
        }
    }
}