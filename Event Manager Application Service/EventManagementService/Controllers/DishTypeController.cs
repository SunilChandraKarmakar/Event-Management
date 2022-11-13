using AutoMapper;
using EventManagementService.Model.ResponseModels;
using EventManagementService.Model.ViewModels.DishType;
using EventManagementService.RepositoryService.DishService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DishTypeController : ControllerBase
    {
        private readonly IDishTypeRepository _dishTypeRepository;
        private readonly IMapper _mapper;

        public DishTypeController(IDishTypeRepository dishTypeRepository, IMapper mapper)
        {
            _dishTypeRepository = dishTypeRepository;
            _mapper = mapper;
        }

        // GET: api/<DishTypeController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<ICollection<DishTypeViewModel>>> GetDishTypes()
        {
            var dishTypes = _mapper.Map<ICollection<DishTypeViewModel>>(await _dishTypeRepository.GetDishTypes());

            if (dishTypes == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Dish Types not found! Try again.", null));

            return Ok(dishTypes);
        }
    }
}