using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface INotificationDal : IGenericDal<Notification>
	{
		int GetCountNotificationIsFalse();
		List<Notification> GetNotificationsAllFalse();
		void ChangeNotificationStatusToTrue(int id);
		void ChangeNotificationStatusToFalse(int id);
    }
}

