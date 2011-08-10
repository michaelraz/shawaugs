using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ICreateRequestsTheFrontControllerCanProcess
    {
        object map_from(HttpContext incoming_request);
    }

    public class CreateRequestsTheFrontControllerCanProcess : ICreateRequestsTheFrontControllerCanProcess
    {
        public object map_from(HttpContext incoming_request)
        {
            return incoming_request.Request;
        }
    }
}