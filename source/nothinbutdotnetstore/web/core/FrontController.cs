using System;

namespace nothinbutdotnetstore.web.core
{
    public class FrontController : IProcessWebRequests
    {
        readonly IFindCommandsThatCanProcessRequests command_registry;

        public FrontController(IFindCommandsThatCanProcessRequests commandRegistry)
        {
            command_registry = commandRegistry;
        }

        public void process(IContainRequestInformation the_request)
        {
            IProcessOneSpecificRequest command = command_registry.get_command_for(the_request);
            command.process(the_request);
        }
    }
}