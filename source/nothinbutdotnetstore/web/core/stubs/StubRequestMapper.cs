using System.Web;
using nothinbutdotnetstore.web.application;

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
            public InputModel map<InputModel>()
            {
                object department = new Department();
                return (InputModel) department;
            }
        }
    }
}