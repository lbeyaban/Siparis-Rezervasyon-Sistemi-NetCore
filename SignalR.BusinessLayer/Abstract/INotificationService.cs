using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface INotificationService : IGenericService<Notification>
	{
        int TGetCountNotificationIsFalse();
        List<Notification> TGetNotificationsAllFalse();
        void TChangeNotificationStatusToTrue(int id);
        void TChangeNotificationStatusToFalse(int id);
    }
}

