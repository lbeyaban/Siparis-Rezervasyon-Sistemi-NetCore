using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ProductDto;
using SignalRWebUI.Dtos.CategoryDto;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        // GET: /<controller>/
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            ArrayList categories = new ArrayList();
            
            var responseMessage = await client.GetAsync("https://localhost:7022/api/Product/GetProductsWithCategories");
            var responseMessage2 = await client2.GetAsync("https://localhost:7022/api/Category");
            
            if(responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData2);
                if(values2 != null)
                {
                    foreach (var item in values2)
                    {
                        categories.Add(item.CategoryName);
                    }
                    ViewBag.Categories = categories;
                }
            }
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}

