using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ICreateRequestsTheFrontControllerCanProcess
    {
        IContainRequestInformation map_from(HttpContext incoming_request);
    }

}