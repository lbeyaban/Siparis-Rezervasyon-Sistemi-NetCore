using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
               Location = createContactDto.Location,
               Phone = createContactDto.Phone,
               Mail = createContactDto.Mail,
               FooterTitle = createContactDto.FooterTitle,
               FooterDescription = createContactDto.FooterDescription,
               OpenDays = createContactDto.OpenDays,
               OpenDaysDescription = createContactDto.OpenDaysDescription,
               OpenHours = createContactDto.OpenHours,
            });

            return Ok("İletisim bilgisi başarılı bir şekilde eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Kategori başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = updateContactDto.ContactID,
                Location = updateContactDto.Location,
                Phone = updateContactDto.Phone,
                Mail = updateContactDto.Mail,
                FooterTitle = updateContactDto.FooterTitle,
                FooterDescription = updateContactDto.FooterDescription,
                OpenDays = updateContactDto.OpenDays,
                OpenDaysDescription = updateContactDto.OpenDaysDescription,
                OpenHours = updateContactDto.OpenHours,
            });

            return Ok("İletişim bilgileri Başarılı bir şekilde guncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

    }
}

