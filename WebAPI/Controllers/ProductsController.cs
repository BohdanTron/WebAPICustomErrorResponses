using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new();

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Products);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Product product)
        {
            Products.Add(product);
            return Ok();
        }
    }
}
