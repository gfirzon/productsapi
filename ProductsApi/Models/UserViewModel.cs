using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Models
{
    public class UserViewModel : User
    {
        public string RoleName { get; set; }
    }
}
