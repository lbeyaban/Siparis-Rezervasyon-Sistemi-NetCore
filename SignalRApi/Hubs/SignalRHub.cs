﻿using Microsoft.AspNetCore.SignalR;
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
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        public static int clientCount { get; set; } = 0;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
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

        public async Task SendProgressBarStatistic()
        {
            var value = _moneyCaseService.TGetMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveMoneyCaseAmount", value.ToString("0.00" + "₺"));

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrders", value2);

            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveActiveMenuTables", value3);
        }

        public async Task SendBookingList()
        {
            var values = _bookingService.TGetAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendFalseNotificationCount()
        {
            var value = _notificationService.TGetCountNotificationIsFalse();
            await Clients.All.SendAsync("ReceiveFalseNotificationCount", value);

            var value2 = _notificationService.TGetNotificationsAllFalse();
            await Clients.All.SendAsync("ReceiveAllFalseNotifications", value2);
        }

        public async Task SendMenuTableWithStatus()
        {
            var value = _menuTableService.TGetAll();
            await Clients.All.SendAsync("ReceiveMenuTableWithStatus", value);
        }

        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }

    }
}
