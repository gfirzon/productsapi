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
        public ActionResult<IEnumerable<Product>> Get()
        {
            ActionResult actionResult = null;

            try
            {
                List<Product> list = productService.GetProductList();
                if (list != null)
                {
                    actionResult = Ok(list);
                }
                else
                {
                    actionResult = NotFound();
                }
            }
            catch (Exception ex) 
            {
                string message = $"Unable to process update request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }
            return actionResult;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            ActionResult actionResult = null;

            try
            {
                Product product = productService.GetProduct(id);

                if (product != null)
                {
                    actionResult = Ok(product);
                }
                else
                {
                    actionResult = NotFound();
                }
            }
            catch (Exception ex)
            {
                string message = $"Unable to process update request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;

        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<int> Post(Product product)
        {
            ActionResult actionResult = null;

            try
            {
                int id = productService.CreateProduct(product);

                if (id != 0)
                {
                    actionResult = Ok(product);
                }
                else
                {
                    actionResult = NotFound();
                }
            }
            catch (Exception ex)
            {
                string message = $"Unable to process update request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;
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
