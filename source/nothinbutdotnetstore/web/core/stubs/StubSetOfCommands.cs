using System.Collections;
using System.Collections.Generic;
using System.Web;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<IProcessOneSpecificRequest>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IProcessOneSpecificRequest> GetEnumerator()
        {
            //yield return new RequestCommand(x => HttpContext.Current.Request.Path., new ViewProductsForDepartment());
            yield return new RequestCommand(x => true, new ViewProductsForDepartment());
        }
    }
}