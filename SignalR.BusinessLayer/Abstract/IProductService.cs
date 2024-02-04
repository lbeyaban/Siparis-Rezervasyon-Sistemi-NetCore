using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        int TGetProductCount();
		int TGetProductCountByCategoryNameHamburger();
		int TGetProductCountByCategoryNameMakarna();
		decimal TGetProductAvg();
		string TProductNameByMaxPrice();
		string TProductNameByMinPrice();
		decimal TGetProductPriceByHamburgerAvg();


	}
}
