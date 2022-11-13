using AutoMapper;
using EventManagementService.Model.ResponseModels;
using EventManagementService.Model.ViewModels.FoodType;
using EventManagementService.RepositoryService.FoodTypeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodTypeController : ControllerBase
    {
        private readonly IFoodTypeRepository _foodTypeRepository;
        private readonly IMapper _mapper;

        public FoodTypeController(IFoodTypeRepository foodTypeRepository, IMapper mapper)
        {
            _foodTypeRepository = foodTypeRepository;
            _mapper = mapper;
        }

        // GET: api/<FoodTypeController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<ICollection<FoodTypeViewModel>>> GetFoodTypes()
        {
            var foodTypes = _mapper.Map<ICollection<FoodTypeViewModel>>(await _foodTypeRepository.GetFoodTypes());

            if (foodTypes == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Food Types not found! Try again.", null));

            return Ok(foodTypes);
        }
    }
}