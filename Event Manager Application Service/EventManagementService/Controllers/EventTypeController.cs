using AutoMapper;
using EventManagementService.Model.ResponseModels;
using EventManagementService.Model.ViewModels.EventType;
using EventManagementService.RepositoryService.EventTypeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IMapper _mapper;

        public EventTypeController(IEventTypeRepository eventTypeRepository, IMapper mapper)
        {
            _eventTypeRepository = eventTypeRepository;
            _mapper = mapper;   
        }

        // GET: api/<EventTypeController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<ICollection<EventTypeViewModel>>> GetEventTypes()
        {
            var eventTypes = _mapper.Map<ICollection<EventTypeViewModel>>(await _eventTypeRepository.GetEventTypes());

            if (eventTypes == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Event Types not found! Try again.", null));

            return Ok(eventTypes);
        }
    }
}