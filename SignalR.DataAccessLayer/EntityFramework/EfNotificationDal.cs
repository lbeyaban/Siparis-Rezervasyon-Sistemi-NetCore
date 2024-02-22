using System;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeNotificationStatusToFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Where(x => x.NotificationID == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
           
        }

        public void ChangeNotificationStatusToTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Where(x => x.NotificationID == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
        }

        public int GetCountNotificationIsFalse()
        {
            using var context = new SignalRContext();
            return context.Notifications.Where(x => x.Status == false).Count();
        }

        public List<Notification> GetNotificationsAllFalse()
        {
            using var context = new SignalRContext();
            return context.Notifications.Where(x => x.Status == false).ToList();
        }
    }
}

