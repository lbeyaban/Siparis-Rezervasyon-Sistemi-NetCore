using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IBasketDal : IGenericDal<Basket>
	{
		List<Basket> GetBasketByTableNumber(int id);

	}
}

