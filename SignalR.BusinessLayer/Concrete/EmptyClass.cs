using System;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class EmptyClass : IBasketService
    {
        public void TAdd(Basket entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Basket entity)
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Basket TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}

