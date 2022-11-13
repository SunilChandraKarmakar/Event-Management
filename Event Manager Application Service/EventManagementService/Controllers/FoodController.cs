using AutoMapper;
using EventManagementService.Model.Models;
using EventManagementService.Model.ResponseModels;
using EventManagementService.Model.ViewModels.Food;
using EventManagementService.RepositoryService.FoodService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public FoodController(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{userId}")]
        public async Task<ActionResult<ICollection<FoodViewModel>>> GetFoods(string userId)
        {
            if (String.IsNullOrEmpty(userId))
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Food id can not found! Try again.", null));

            var foods = _mapper.Map<ICollection<FoodViewModel>>(await _foodRepository.GetFoods(userId));

            if (foods == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Food can not found! Try again.", null));

            return Ok(foods);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<FoodUpdateViewModel>>> GetFood(int? id)
        {
            if (id == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Id can not found! Try again.", null));

            var foodVenue = _mapper.Map<FoodUpdateViewModel>(await _foodRepository.GetFood(id));

            if (foodVenue == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Food can not found! Try again.", null));

            return Ok(foodVenue);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public async Task<ActionResult<ICollection<FoodUpdateViewModel>>> Update(int? id, FoodUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                    return BadRequest(new ResponseStatus(ResponseCode.Error, "Id can not found! Try again.", null));

                var existFood = _mapper.Map<Food>(model);

                if (existFood == null)
                    return BadRequest(new ResponseStatus(ResponseCode.Error, "Food can not found! Try again.", null));

                var isUpdate = await _foodRepository.Update(existFood);

                if (isUpdate)
                    return Ok(new ResponseStatus(ResponseCode.Ok, "Food has been updated successfull.", model));

                return BadRequest(new ResponseStatus(ResponseCode.Error, "Food can not updated! Try again.", null));
            }

            return BadRequest(new ResponseStatus(ResponseCode.FormValidateError, "Food form validate error.", ModelState));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<FoodCreateViewModel>> Create(FoodCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createdFood = _mapper.Map<Food>(model);
                var isCreated = await _foodRepository.Create(createdFood);

                if (isCreated)
                    return Ok(new ResponseStatus(ResponseCode.Ok, "Food create successfull.", model));

                return BadRequest(new ResponseStatus(ResponseCode.Error, "Food not create! Try again.", null));
            }

            return BadRequest(new ResponseStatus(ResponseCode.FormValidateError, "Food form validate error.", ModelState));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodDeleteViewModel>> Delete(int? id)
        {
            if (id == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Food id can not found! Try again.", null));

            var isDeleted = await _foodRepository.Remove(id);

            if (isDeleted)
                return Ok(new ResponseStatus(ResponseCode.Ok, "Food has been deleted successfull", null));

            return BadRequest(new ResponseStatus(ResponseCode.Error, "Food can not deleted! Try again.", null));
        }
    }
}