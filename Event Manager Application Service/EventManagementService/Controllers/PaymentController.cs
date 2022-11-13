using AutoMapper;
using EventManagementService.Model.Models;
using EventManagementService.Model.ResponseModels;
using EventManagementService.Model.ViewModels.Payment;
using EventManagementService.RepositoryService.PaymentService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{userId}")]
        public async Task<ActionResult<ICollection<PaymentViewModel>>> GetPayments(string userId)
        {
            if (String.IsNullOrEmpty(userId))
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Payment id can not found! Try again.", null));

            var payments = _mapper.Map<ICollection<PaymentViewModel>>(await _paymentRepository.GetPayments(userId));

            if (payments == null)
                return BadRequest(new ResponseStatus(ResponseCode.Error, "Payment can not found! Try again.", null));

            return Ok(payments);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<PaymentCreateViewModel>> Create(PaymentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createdPayment = _mapper.Map<Payment>(model);
                var isCreated = await _paymentRepository.Create(createdPayment);

                if (isCreated)
                    return Ok(new ResponseStatus(ResponseCode.Ok, "Payment create successfull.", model));

                return BadRequest(new ResponseStatus(ResponseCode.Error, "Payment not create! Try again.", null));
            }

            return BadRequest(new ResponseStatus(ResponseCode.FormValidateError, "Payment form validate error.", ModelState));
        }
    }
}