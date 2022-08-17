using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.ViewModels.Category
{
    public class ListCategoryForListVm
    {
        public List<CategoryForListVm> Categories { get; set; }
        public int Count { get; set; }
    }
}
