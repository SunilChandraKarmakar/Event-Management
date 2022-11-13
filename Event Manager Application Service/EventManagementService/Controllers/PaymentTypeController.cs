using AutoMapper;
using EventManagementService.Model.ResponseModels;
using EventManagementService.Model.ViewModels.PaymentType;
using EventManagementService.RepositoryService.PaymentTypeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IMapper _mapper;

        public PaymentTypeController(IPaymentTypeRepository paymentTypeRepository, IMapper mapper)
        {
            _paymentTypeRepository = paymentTypeRepository;
            _mapper = mapper;
        }

        // GET: api/<PaymentTypeController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<ICollection<PaymentTypeViewModel>>> GetPaymentTypes()
        {
            var paymentTypes = _mapper.Map<ICollection<PaymentTypeViewModel>>(await _paymentTypeRepository.GetPaymentTypes());

            if (paymentTypes == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Payment Types not found! Try again.", null));

            return Ok(paymentTypes);
        }
    }
}
