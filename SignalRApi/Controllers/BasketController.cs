using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult BasketList()
        {
            var values = _basketService.TGetAll();
            return Ok(values);
        }

        [HttpGet("GetBasketListWithProductName/{id}")]
        public IActionResult GetBasketListWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id)
                .Select(z => new ResultBasketWithProducts
                {
                    BasketID = z.BasketID,
                    ProductID = z.ProductID,
                    Price = z.Price,
                    Count = z.Count,
                    TotalPrice = z.TotalPrice,
                    MenuTableID = z.MenuTableID,
                    ProductName = z.Product.ProductName
                }).ToList();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public IActionResult GetBasketListByTableID(int id)
        {
            var values = _basketService.TGetBasketByTableNumber(id);
            return Ok(values);
        }

        [HttpPost("{id}")]
        public IActionResult CreateBasket(int id)
        {
            CreateBasketDto createBasketDto = new CreateBasketDto();
            createBasketDto.ProductID = id;
            using var context = new SignalRContext();
            Basket basket = new Basket()
            {
                ProductID = createBasketDto.ProductID,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                Count = 1,
                TotalPrice = 20,
                MenuTableID = 4
            };
           
            _basketService.TAdd(basket);
            return Ok("Sepet başarılı bir şekilde oluşturuldu.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepet başarılı bir şekilde silindi.");
        }

        
    }
}

