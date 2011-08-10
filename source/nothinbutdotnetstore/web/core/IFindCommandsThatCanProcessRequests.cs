namespace nothinbutdotnetstore.web.core
{
    public interface IFindCommandsThatCanProcessRequests
    {
        IProcessOneSpecificRequest get_command_for(IContainRequestInformation the_request);
    }
}