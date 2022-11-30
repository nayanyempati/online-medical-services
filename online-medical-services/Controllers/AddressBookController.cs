using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_medical_services.Helpers;
using online_medical_services.Interfaces;

namespace online_medical_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAddressbook _addressBook;
        private readonly Messages _message = new Messages();
        public AddressBookController(ILogger<AddressBookController> logger, IAddressbook addressBook)
        {
            _logger = logger;
            _addressBook = addressBook;
        }
    }
}
