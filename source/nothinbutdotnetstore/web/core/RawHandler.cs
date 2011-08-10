using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class RawHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            throw new System.NotImplementedException();
        }

        public bool IsReusable
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}