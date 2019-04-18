using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using ProductsApi.Services;
using Microsoft.AspNetCore.Http;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService vendorService;

        public VendorsController(IVendorService vendorService)
        {
            this.vendorService = vendorService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Vendor>> Get()
        {
            ActionResult actionResult = null;

            try
            {
                List<Vendor> list = vendorService.GetVendorList();
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
                string message = $"Unable to process GetVendor request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Vendor> Get(int id)
        {
            ActionResult actionResult = null;

            try
            {
                Vendor vendor = vendorService.GetVendor(id);
                if (vendor != null)
                {
                    actionResult = Ok(vendor);
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

        // POST api/values
        [HttpPost]
        public ActionResult<int> Post(Vendor vendor)
        {
            ActionResult actionResult = null;

            try
            {
                int id = vendorService.CreateVendor(vendor);

                if (vendor != null)
                {
                    actionResult = Ok(vendor);
                    return id;
                }
                else
                {
                    actionResult = NotFound();
                }
            }
            catch (Exception ex)
            {
                string message = $"Unable to process Create Vendor request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;
        }


        // PUT api/values/5
        [HttpPut]
        public ActionResult Put(Vendor vendor)
        {
            ActionResult actionResult = null;

            try
            {
                vendorService.UpdateVendor(vendor);
                if (vendor != null)
                {
                    actionResult = Ok(vendor);
                }
                else
                {
                    actionResult = NotFound();
                }
            }
            catch (Exception ex)
            {
                string message = $"Unable to process Update Vendor request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;
        }
    }
}
