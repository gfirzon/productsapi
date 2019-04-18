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
            List<Vendor> list = vendorService.GetVendorList();
            return list;
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
            int id = vendorService.CreateVendor(vendor);
            return id;
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(Vendor vendor)
        {
            vendorService.UpdateVendor(vendor);
            //return vendorService.UpdateVendor(vendor);

            //if (Vendor == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return Ok(Vendor);
            //}
        }
    }
}
