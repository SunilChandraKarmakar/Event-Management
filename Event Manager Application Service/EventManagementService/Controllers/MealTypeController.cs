using AutoMapper;
using EventManagementService.Model.ResponseModels;
using EventManagementService.Model.ViewModels.MealType;
using EventManagementService.RepositoryService.MealTypeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MealTypeController : ControllerBase
    {
        private readonly IMealTypeRepository _mealTypeRepository;
        private readonly IMapper _mapper;

        public MealTypeController(IMealTypeRepository mealTypeRepository, IMapper mapper)
        {
            _mealTypeRepository = mealTypeRepository;
            _mapper = mapper;
        }

        // GET: api/<MealTypeController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<ICollection<MealTypeViewModel>>> GetMealTypes()
        {
            var mealTypes = _mapper.Map<ICollection<MealTypeViewModel>>(await _mealTypeRepository.GetMealTypes());

            if (mealTypes == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Meal Types not found! Try again.", null));

            return Ok(mealTypes);
        }
    }
}