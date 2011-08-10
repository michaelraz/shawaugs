using System;

namespace nothinbutdotnetstore.web.core
{
    public interface IProcessWebRequests 
    {
        void process(object the_request);
    }

    public class Front_Controller :  IProcessWebRequests
    {
        public void process(object the_request)
        {
            
        }
    }
}