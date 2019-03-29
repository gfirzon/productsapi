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
            Vendor vendor = vendorService.GetVendor(id);
            return vendor;
            //return new Vendor { VendorId = id, VendorName = "CCC", Phone = "0000000000" };
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int n = 1;
        }
    }
}
