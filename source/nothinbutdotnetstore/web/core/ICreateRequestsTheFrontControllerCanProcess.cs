using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ICreateRequestsTheFrontControllerCanProcess
    {
        object map_from(HttpContext incoming_request);
    }
}