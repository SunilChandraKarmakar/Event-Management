using AutoMapper;
using EventManagementService.Model.Models;
using EventManagementService.Model.ResponseModels;
using EventManagementService.Model.ViewModels.User;
using EventManagementService.Model.ViewModels.Venue;
using EventManagementService.RepositoryService.VenueService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IVenueRepository _venueRepository;
        private readonly IMapper _mapper;

        public VenueController(IVenueRepository venueRepository, IMapper mapper)
        {
            _venueRepository = venueRepository;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{userId}")]
        public async Task<ActionResult<ICollection<VenueViewModel>>> GetVenues(string userId)
        {
            if(String.IsNullOrEmpty(userId))
                return BadRequest(new ResponseStatus(ResponseCode.Error, "User id can not found! Try again.", null));

            var venues = _mapper.Map<ICollection<VenueViewModel>>(await _venueRepository.GetVenues(userId));

            if(venues == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Venues can not found! Try again.", null));

            return Ok(venues);  
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<VenueUpdateViewModel>>> GetVenue(int? id)
        {
            if (id == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Id can not found! Try again.", null));

            var existVenue = _mapper.Map<VenueUpdateViewModel>(await _venueRepository.GetVenue(id));

            if (existVenue == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Venues can not found! Try again.", null));

            return Ok(existVenue);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public async Task<ActionResult<ICollection<VenueUpdateViewModel>>> Update(int? id, VenueUpdateViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (id == null)
                    return BadRequest(new ResponseStatus(ResponseCode.Error, "Id can not found! Try again.", null));

                var existVenue = _mapper.Map<Venue>(model);

                if (existVenue == null)
                    return BadRequest(new ResponseStatus(ResponseCode.Error, "Venues can not found! Try again.", null));

                var isUpdate = await _venueRepository.Update(existVenue);

                if(isUpdate)
                    return Ok(new ResponseStatus(ResponseCode.Ok, "Venue has been updated successfull.", model));

                return BadRequest(new ResponseStatus(ResponseCode.Error, "Venue can not updated! Try again.", null));
            }

            return BadRequest(new ResponseStatus(ResponseCode.FormValidateError, "Venue form validate error.", ModelState));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<VenueCreateViewModel>> Create(VenueCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var createdVenue = _mapper.Map<Venue>(model);
                var isCreated = await _venueRepository.Create(createdVenue);

                if(isCreated)
                    return Ok(new ResponseStatus(ResponseCode.Ok, "Venue create successfull.", model));

                return BadRequest(new ResponseStatus(ResponseCode.Error, "Venue not create! Try again.", null));
            }

            return BadRequest(new ResponseStatus(ResponseCode.FormValidateError, "Venue form validate error.", ModelState));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<VenueDeleteViewModel>> Delete(int? id)
        {
            if (id == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Venue id can not found! Try again.", null));

            var isDeleted = await _venueRepository.Remove(id);

            if(isDeleted)
                return Ok(new ResponseStatus(ResponseCode.Ok, "Value has been deleted successfull", null));

            return BadRequest(new ResponseStatus(ResponseCode.Error, "Value can not deleted! Try again.", null));
        }
    }
}