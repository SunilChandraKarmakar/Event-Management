using AutoMapper;
using EventManagementService.Model.ResponseModels;
using EventManagementService.Model.ViewModels.EventType;
using EventManagementService.Model.ViewModels.VenueType;
using EventManagementService.RepositoryService.VenueTypeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VenueTypeController : ControllerBase
    {
        private readonly IVenueTypeRepository _venueTypeRepository;
        private readonly IMapper _mapper;

        public VenueTypeController(IVenueTypeRepository venueTypeRepository, IMapper mapper)
        {
            _venueTypeRepository = venueTypeRepository;
            _mapper = mapper;
        }

        // GET: api/<VenueTypeController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<ICollection<VenueTypeViewModel>>> GetVenueTypes()
        {
            var eventTypes = _mapper.Map<ICollection<VenueTypeViewModel>>(await _venueTypeRepository.GetVenueTypes());

            if (eventTypes == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Venue Types not found! Try again.", null));

            return Ok(eventTypes);
        }
    }
}