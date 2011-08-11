using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application
{
    public interface IReturnProducts
    {
        IEnumerable<Product> get_the_products_of(Department department);
    }
}