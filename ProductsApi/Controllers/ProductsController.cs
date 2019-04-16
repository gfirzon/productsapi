using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult <IEnumerable<Product>> Get()
        {
            List<Product> list = productService.GetProductList();
            return list;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product = productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<int> Post(Product product)
        {
            int id = productService.CreateProduct(product);

            return id;
        }

        // PUT: api/Products/5
        [HttpPut]
        public ActionResult Put(Product product)
        {
            ActionResult actionResult = null;

            try
            {
                bool isUpdated = productService.UpdateProduct(product);

                if (isUpdated == true)
                {
                    actionResult = Ok("Product updated....");
                }
                else
                {
                    actionResult = NotFound();
                }
            }
            catch (Exception ex)
            {
                //string message = string.Format("Unable to process update request: {0}", ex.Message);
                string message = $"Unable to process update request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;
        }
    }
}
