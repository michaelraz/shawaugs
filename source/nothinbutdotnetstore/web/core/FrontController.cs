namespace nothinbutdotnetstore.web.core
{
    public class FrontController : IProcessWebRequests
    {
        IFindCommandsThatCanProcessRequests command_registry;

        public FrontController(IFindCommandsThatCanProcessRequests command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(IContainRequestInformation the_request)
        {
            command_registry.get_command_for(the_request).process(the_request);
        }
    }
}