using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestMapper : ICreateRequestsTheFrontControllerCanProcess
    {
        public IContainRequestInformation map_from(HttpContext incoming_request)
        {
            return new StubRequest();
        }

        class StubRequest : IContainRequestInformation
        {
        }
    }
}