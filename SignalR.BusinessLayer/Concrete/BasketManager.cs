using System;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> TGetAll()
        {
            return _basketDal.GetAll();
        }

        public Basket TGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public void TUpdate(Basket entity)
        {
            _basketDal.Update(entity);
        }
    }
}

