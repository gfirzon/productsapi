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
        public ActionResult Get()
        {
            ActionResult actionResult = null;

            try
            {
                List<Vendor> list = vendorService.GetVendorList();
                if (list != null)
                {
                    actionResult = Ok(list);
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
        public ActionResult Get(int id)
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
        public ActionResult Post(Vendor vendor)
        {
            ActionResult actionResult = null;
            bool err500 = false;
            string errMessage = null;

            try
            {
                int id = vendorService.CreateVendor(vendor);

                if (id != 0)
                {
                    actionResult = Ok(id);
                }
                else
                {
                    err500 = true;
                    errMessage = "vendorService.CreateVendor returned 0";
                }
            }
            catch (Exception ex)
            {
                err500 = true;
                errMessage = ex.Message;
            }
            finally
            {
                if (err500)
                {
                    string message = $"Unable to process Create Vendor request: {errMessage}";
                    actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
                }
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
                bool isUpdated = vendorService.UpdateVendor(vendor);
                if (isUpdated == true)
                {
                    actionResult = Ok();
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
