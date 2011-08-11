using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.application.stubs
{
        public class StubProductRepository : IReturnProducts 
        {
            public IEnumerable<Product> get_the_products_of(Department department)
            {
                return Enumerable.Range(1, 100).Select(x => new Product {name = x.ToString("Department 0")});
            }
        }
}