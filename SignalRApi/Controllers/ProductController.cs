using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
		
		private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList() 
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
            return Ok(values);
        }

		[HttpGet("GetProductAvg")]
		public IActionResult GetProductAvg()
		{
			return Ok(_productService.TGetProductAvg());
		}

		[HttpGet("GetProductPriceByHamburgerAvg")]
		public IActionResult GetProductPriceByHamburgerAvg()
		{
			return Ok(_productService.TGetProductPriceByHamburgerAvg());
		}

		[HttpGet("GetProductCount")]
		public IActionResult GetProductCount()
		{
			return Ok(_productService.TGetProductCount());
		}

		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice());
		}

		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNameByMaxPrice());
		}

		[HttpGet("GetProductCountByCategoryNameHamburger")]
		public IActionResult GetProductCountByCategoryNameHamburger()
		{
			return Ok(_productService.TGetProductCountByCategoryNameHamburger());
		}

		[HttpGet("GetProductCountByCategoryNameMakarna")]
		public IActionResult GetProductCountByCategoryNameMakarna()
		{
			return Ok(_productService.TGetProductCountByCategoryNameMakarna());
		}

		[HttpGet("GetProductsWithCategories")]
        public IActionResult GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory()
            {
                CategoryName = y.Category.CategoryName,
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,

            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
           _productService.TAdd(new Product()
           {
               ProductName = createProductDto.ProductName,
               ProductStatus = createProductDto.ProductStatus,
               Description = createProductDto.Description,
               Price = createProductDto.Price,
               ImageUrl = createProductDto.ImageUrl,
               CategoryID = createProductDto.CategoryID
           });

           return Ok("Urun başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id) 
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Urun başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto) 
        {
            _productService.TUpdate(new Product()
            {
                ProductID = updateProductDto.ProductID,
                ProductName = updateProductDto.ProductName,
                ProductStatus = updateProductDto.ProductStatus,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                ImageUrl = updateProductDto.ImageUrl,
                CategoryID = updateProductDto.CategoryID
            });

            return Ok("Urun başarıyla guncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id) 
        {
            var value = _productService.TGetById(id);
            return Ok(value);

        }

    }
}
