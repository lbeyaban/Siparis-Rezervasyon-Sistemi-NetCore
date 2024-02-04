using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            this.featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(featureService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            featureService.TAdd(new Feature()
            {
                Title1 = createFeatureDto.Title1,
                Description1 = createFeatureDto.Description1,
                Title2 = createFeatureDto.Title2,
                Description2 = createFeatureDto.Description2,
                Title3 = createFeatureDto.Title3,
                Description3 = createFeatureDto.Description3,
            });

            return Ok("Feature bilgisi başarılı bir şekilde eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = featureService.TGetById(id);
            featureService.TDelete(value);
            return Ok("Feature başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            featureService.TUpdate(new Feature()
            {
                FeatureID = updateFeatureDto.FeatureID,
                Title1 = updateFeatureDto.Title1,
                Description1 = updateFeatureDto.Description1,
                Title2 = updateFeatureDto.Title2,
                Description2 = updateFeatureDto.Description2,
                Title3 = updateFeatureDto.Title3,
                Description3 = updateFeatureDto.Description3,
            });

            return Ok("Feature Başarılı bir şekilde guncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = featureService.TGetById(id);
            return Ok(value);
        }
    }
}
