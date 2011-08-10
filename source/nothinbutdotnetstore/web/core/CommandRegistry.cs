namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : IFindCommandsThatCanProcessRequests
    {
        public IProcessOneSpecificRequest get_command_for(IContainRequestInformation the_request)
        {
            throw new System.NotImplementedException();
        }
    }
}