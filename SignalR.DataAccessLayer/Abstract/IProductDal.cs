using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int GetProductCount();
        int GetProductCountByCategoryNameHamburger();
        int GetProductCountByCategoryNameMakarna();
        decimal GetProductAvg();
        decimal GetProductPriceByHamburgerAvg();
		string ProductNameByMaxPrice();
        string ProductNameByMinPrice();

	}
}
