using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList() 
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(ResultDiscountDto resultDiscountDto) 
        {
            _discountService.TAdd(new Discount()
            {
                Title = resultDiscountDto.Title,
                Amount = resultDiscountDto.Amount,
                Description = resultDiscountDto.Description,
                ImageUrl = resultDiscountDto.ImageUrl,

            });
            return Ok("İndirim Başarılı bir şekilde eklenmiştir.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id) 
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto) 
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountID = updateDiscountDto.DiscountID,
                Title = updateDiscountDto.Title,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl,
            });

            return Ok("İndirim başarılıyla güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }


    }
}
