using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;   
        }

        public async Task SendStatistic()
		{
			var value = _categoryService.TGetCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value1 = _categoryService.TGetTrueCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value1);

            var value2 = _categoryService.TGetFalseCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value2);

            var value3 = _productService.TGetProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value3);

            var value4 = _productService.TGetProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveGetProductCountByCategoryNameHamburger", value4);

            var value5 = _productService.TGetProductCountByCategoryNameMakarna();
            await Clients.All.SendAsync("ReceiveGetProductCountByCategoryNameMakarna", value5);

            var value6 = _productService.TGetProductAvg();
            await Clients.All.SendAsync("ReceiveGetProductAvg", value6.ToString("0.00") + "₺");

            //var value7 = _productService.TProductNameByMaxPrice();
            var value7 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value7);

            var value8 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value8);

            var value9 = _productService.TGetProductPriceByHamburgerAvg();
            await Clients.All.SendAsync("ReceiveAvgHambugerPrice", value9); 

            var value10 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrder", value10);
            
            var value11 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrders", value11); 

            var value12 = _orderService.TLastOrderTotalPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", value12);

            var value13 = _moneyCaseService.TGetMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value13);
            
            //var value14 = _orderService.TTodayTotalPrice();
            //await Clients.All.SendAsync("ReceiveTotalAmountForToday", value14);

            var value15 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value15);


        }


    }
}
