using System;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TChangeNotificationStatusToFalse(int id)
        {
            _notificationDal.ChangeNotificationStatusToFalse(id);
        }

        public void TChangeNotificationStatusToTrue(int id)
        {
            _notificationDal.ChangeNotificationStatusToTrue(id);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> TGetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public int TGetCountNotificationIsFalse()
        {
            return _notificationDal.GetCountNotificationIsFalse();
        }

        public List<Notification> TGetNotificationsAllFalse()
        {
            return _notificationDal.GetNotificationsAllFalse();
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}

