using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {

        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            Notification notification = new Notification()
            {
                Type = createNotificationDto.Type,
                Description = createNotificationDto.Description,
                Icon = createNotificationDto.Icon,
                Status = createNotificationDto.Status,
                Date = createNotificationDto.Date
            };

            _notificationService.TAdd(notification);

            return Ok("Bildirim başarılı bir şekilde oluşturuldu.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Rezervasyon başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification()
            {
                NotificationID = updateNotificationDto.NotificationID,
                Type = updateNotificationDto.Type,
                Description = updateNotificationDto.Description,
                Icon = updateNotificationDto.Icon,
                Status = updateNotificationDto.Status,
                Date = updateNotificationDto.Date,
            };

            _notificationService.TUpdate(notification);
            
            return Ok("Bildirim Güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("ChangeNotificationStatusToTrue/{id}")]
        public IActionResult ChangeNotificationStatusToTrue(int id)
        {
            _notificationService.TChangeNotificationStatusToTrue(id);
            return Ok("Bildirim durumu görüldü olarak değiştirildi.");
        }

        [HttpGet("ChangeNotificationStatusToFalse/{id}")]
        public IActionResult ChangeNotificationStatusToFalse(int id)
        {
            _notificationService.TChangeNotificationStatusToFalse(id);
            return Ok("Bildirim durumu görülmedi olarak değiştirildi.");
        }


    }
}

