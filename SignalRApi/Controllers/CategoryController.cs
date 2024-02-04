using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList() 
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetAll());
            return Ok(values);
        }

		[HttpGet("GetCategoryCount")]
		public IActionResult GetCategoryCount()
		{
			return Ok(_categoryService.TGetCategoryCount());
		}

		[HttpGet("GetTrueCategoryCount")]
		public IActionResult GetTrueCategoryCount()
		{
			return Ok(_categoryService.TGetTrueCategoryCount());
		}

		[HttpGet("GetFalseCategoryCount")]
		public IActionResult GetFalseCategoryCount()
		{
			return Ok(_categoryService.TGetFalseCategoryCount());
		}

		[HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.TAdd(new Category() {
                CategoryName = createCategoryDto.CategoryName,
                Status = true
            });

            return Ok("Kategori başarılı bir şekilde eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) 
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Kategori başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto) 
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryName = updateCategoryDto.CategoryName,
                Status = updateCategoryDto.Status,
                CategoryID = updateCategoryDto.CategoryID
            });

            return Ok("Kategori Başarılı bir şekilde guncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }

    }
}
