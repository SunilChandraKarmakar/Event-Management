using AutoMapper;
using EventManagementService.Model.Models;
using EventManagementService.Model.ResponseModels;
using EventManagementService.Model.ViewModels.Login;
using EventManagementService.Model.ViewModels.Register;
using EventManagementService.Model.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace EventManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtConfig;

        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IOptions<JwtConfig> jwtConfig)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtConfig = jwtConfig.Value;
        }

        [HttpPost("RegisterUser")]
        public ActionResult<UserEditViewModel> RegisterUser([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(model);
                user.UserName = model.Email;
                user.CreatedTime = DateTime.UtcNow;
                user.LastModifiedTime = DateTime.UtcNow;

                Task<IdentityResult> result = _userManager.CreateAsync(user, model.Password);
                model = _mapper.Map<RegisterViewModel>(user);

                if (result.Result.Succeeded)
                    return Ok(new ResponseStatus(ResponseCode.Ok, "User has been registered successfull.", model));
                else
                    return BadRequest(new ResponseStatus(ResponseCode.Error, "User registration failed.", result.Result.Errors.Select(s => s.Description).ToArray()));
            }

            return BadRequest(new ResponseStatus(ResponseCode.FormValidateError, "Regsitration form validate error.", ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserViewModel>> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    UserViewModel existUser = _mapper.Map<UserViewModel>(await _userManager.FindByEmailAsync(model.Email));
                    existUser.Token = GenerateToken(existUser);
                    return Ok(new ResponseStatus(ResponseCode.Ok, "Login successfull", existUser));
                }

                return BadRequest(new ResponseStatus(ResponseCode.FormValidateError, "Email and Password can not match, try again.", null));
            }

            return BadRequest(new ResponseStatus(ResponseCode.FormValidateError, "Regsitration form validate error.", ModelState));
        }

        private string GenerateToken(UserViewModel user)
        {
            JwtSecurityTokenHandler jwtTokenHendler = new JwtSecurityTokenHandler();
            byte[] key = System.Text.Encoding.ASCII.GetBytes(_jwtConfig.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience
            };

            var token = jwtTokenHendler.CreateToken(tokenDescriptor);
            return jwtTokenHendler.WriteToken(token);
        }
    }
}