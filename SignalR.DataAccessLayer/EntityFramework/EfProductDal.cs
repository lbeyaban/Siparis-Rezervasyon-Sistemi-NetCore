using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

		public decimal GetProductAvg()
		{
			using var context = new SignalRContext();
			return context.Products.Average(x => x.Price);
		}

		public int GetProductCount()
		{
            using var context = new SignalRContext();
            return context.Products.Count();
		}

		public int GetProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger")
			.Select(z => z.CategoryID).FirstOrDefault())).Count();
		}

		public int GetProductCountByCategoryNameMakarna()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Makarna")
			.Select(z => z.CategoryID).FirstOrDefault())).Count();
		}

		public decimal GetProductPriceByHamburgerAvg()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Category.CategoryName == "Hamburger").Average(y => y.Price);
		}

		public List<Product> GetProductsWithCategories()
        {
            var context =  new SignalRContext();
            var values = context.Products.Include(x =>  x.Category).ToList();
            return values;
        }

		public string ProductNameByMaxPrice()
		{
			using var context = new SignalRContext();
			var value = context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
			return value;
		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();
            var value = context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
            return value;
        }
	}
}
