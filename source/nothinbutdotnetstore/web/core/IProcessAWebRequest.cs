namespace nothinbutdotnetstore.web.core
{
    public interface IProcessOneSpecificRequest : IProcessAnApplicationBehaviour
    {
        bool can_process(IContainRequestInformation request);
    }
}