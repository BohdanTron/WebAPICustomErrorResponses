using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new();

        private readonly IValidator<Product> _productValidator;

        public ProductsController(IValidator<Product> productValidator) => 
            _productValidator = productValidator;

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Products);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Product product)
        {
            var validationResult = _productValidator.Validate(product);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new Error(e.ErrorCode, e.ErrorMessage));
                return BadRequest(errors);
            }

            Products.Add(product);
            return Ok();
        }
    }
}
