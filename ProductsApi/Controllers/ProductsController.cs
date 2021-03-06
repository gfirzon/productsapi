﻿using System;
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
        public ActionResult Get()
        {
            ActionResult actionResult = null;

            try
            {
                List<Product> list = productService.GetProductList();

                if (list != null)
                {
                    actionResult = Ok(list);
                }
            }
            catch (Exception ex) 
            {
                string message = $"Unable to process get request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }
            return actionResult;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
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
                string message = $"Unable to process get request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;

        }

        // POST: api/Products
        [HttpPost]
        public ActionResult Post(Product product)
        {
            ActionResult actionResult = null;
            bool err500 = false;
            string errMessage = null;

            try
            {
                int id = productService.CreateProduct(product);

                if (id != 0)
                {
                    actionResult = Ok(id);
                }
                else
                {
                    err500 = true;
                    errMessage = "userService.CreateProduct returned 0";
                }
            }
            catch (Exception ex)
            {
                err500 = true;
                errMessage = ex.Message;
            }
            finally
            {
                if (err500 == true)
                {
                    string message = $"Unable to process post request - {errMessage}";
                    actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
                }
            }

            return actionResult;
        }

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
