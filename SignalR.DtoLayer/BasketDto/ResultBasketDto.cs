﻿using System;

namespace SignalR.DtoLayer.BasketDto
{
	public class ResultBasketDto
	{
        public int BasketID { get; set; }

        public int ProductID { get; set; }

        public decimal Price { get; set; }

        public decimal Count { get; set; }

        public decimal TotalPrice { get; set; }

        public int MenuTableID { get; set; }


    }
}

