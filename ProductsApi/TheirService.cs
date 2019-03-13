using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi
{
    public class TheirService : ITheirService
    {
        public int faa(string text)
        {
            return text.Length;
        }
    }
}
