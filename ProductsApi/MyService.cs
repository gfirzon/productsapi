using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi
{
    public class MyService : IMyService
    {
        private readonly ITheirService theirService;

        public MyService(ITheirService service)
        {
            theirService = service;
        }

        public int foo(int n, int m)
        {
            return (n * m) + n + m + theirService.faa("Hello"); ;
        }
    }
}
