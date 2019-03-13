using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using System.Data;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IMyService myService;

        public VendorsController(IMyService s)
        {
            myService = s;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Vendor>> Get()
        {
            List<Vendor> list = new List<Vendor> {
                new Vendor{ VendorId = 1, VendorName = "AAA", Phone = "2221113344" },
                new Vendor{ VendorId = 2, VendorName = "BBB", Phone = "3331112222" },
            };

            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Vendor> Get(int id)
        {
            return new Vendor { VendorId = myService.foo(id, id), VendorName = "CCC", Phone = "0000000000" };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Vendor value)
        {
            int n = 1;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vendor value)
        {
            int n = 1;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int n = 1;
        }
    }
}
