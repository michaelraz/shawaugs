using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class RawHandler : IHttpHandler
    {
        readonly IProcessWebRequests process_web_requests;
        readonly ICreateRequestsTheFrontControllerCanProcess create_requests_the_front_controller_can_process;

        public RawHandler(IProcessWebRequests process_web_requests, ICreateRequestsTheFrontControllerCanProcess create_requests_the_front_controller_can_process)
        {
            this.process_web_requests = process_web_requests;
            this.create_requests_the_front_controller_can_process = create_requests_the_front_controller_can_process;
        }

        public void ProcessRequest(HttpContext context)
        {
            object request = create_requests_the_front_controller_can_process.map_from(context);
            process_web_requests.process(request);
        }

        public bool IsReusable
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}