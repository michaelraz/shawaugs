using System.Collections.Generic;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubPathRegistry :IProvidePathsToViews
    {
        public string get_the_path_to_a_page_that_can_display<Report>()
        {
            if (typeof(Report).Equals(typeof(IEnumerable<Department>))) return create_view_to("DepartmentBrowser");
            return create_view_to("ProductBrowser");
        }

        string create_view_to(string page)
        {
            return string.Format("~/views/{0}.aspx", page);
        }
    }
}