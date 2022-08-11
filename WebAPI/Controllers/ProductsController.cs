using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Storage.Products);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Product product)
        {
            Storage.Products.Add(product);
            return Ok();
        }
    }
}
