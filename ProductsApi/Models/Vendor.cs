﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public int VendorID { get; internal set; }
        public string VendorName { get; set; }
        public string VendorPhone { get; set; }
    }
}
