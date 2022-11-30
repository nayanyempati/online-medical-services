using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_medical_services.Helpers;
using online_medical_services.Interfaces;
using online_medical_services.Models;

namespace online_medical_services.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAccount _account;
        private readonly Messages _message=new Messages();
        public AccountController(ILogger<AccountController> logger, IAccount account)
        {
            _logger = logger;
            _account = account;
        }

        [HttpPost("register"), AllowAnonymous]
        public async Task<ResponseMessage> Register([FromBody] UserRegistrationModel register)
        {
            _logger.LogInformation("Entered into Account - Register");
            return await _account.Register(register);
        }

        [HttpPost("activate/{activationtoken}")]
        public async Task<ResponseMessage> ActivateAccount(string activationtoken)
        {
            if (activationtoken != null)
            {
                return await _account.ActivateAccount(activationtoken);
            }
            return new ResponseMessage { Message = _message.MANDATORY_FIELD_MISSING, Status = _message.FAILED };
        }
    }
}
