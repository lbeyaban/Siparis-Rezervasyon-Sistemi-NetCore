﻿using System;
namespace SignalR.DtoLayer.BasketDto
{
	public class CreateBasketDto
	{
        public int ProductID { get; set; }

        public decimal Price { get; set; }

        public decimal Count { get; set; }

        public decimal TotalPrice { get; set; }

        public int MenuTableID { get; set; }
    }
}
