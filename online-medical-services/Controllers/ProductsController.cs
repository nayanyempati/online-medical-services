using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_medical_services.Interfaces;
using online_medical_services.Models;

namespace online_medical_services.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProducts _products;
        public ProductsController(ILogger<ProductsController> logger, IProducts products)
        {
            _logger = logger;
            _products = products;
        }
        [HttpPost("add"), AllowAnonymous]
        public async Task<ResponseMessage> AddProduct([FromBody] AddProductModel product)
        {
            _logger.LogInformation("Entered into Products - AddProduct");
            return await _products.AddProduct(product);
        }
    }
}
