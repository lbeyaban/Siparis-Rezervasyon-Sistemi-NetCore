using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class MenuTableController : Controller
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTableController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                MenuName = createMenuTableDto.MenuName,
                Status = false,

            };

            _menuTableService.TAdd(menuTable);
            return Ok("MenuTable Eklendi.");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);
            return Ok("MenuTable silini.");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                MenuName = updateMenuTableDto.MenuName,
                Status = false,

            };
            _menuTableService.TUpdate(menuTable);
            return Ok("MenuTable Güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var values = _menuTableService.TGetById(id);
            return Ok(values);
        }
    }
}

