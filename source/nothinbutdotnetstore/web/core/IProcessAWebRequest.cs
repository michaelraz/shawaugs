namespace nothinbutdotnetstore.web.core
{
    public interface IProcessOneSpecificRequest 
    {
        void process(IContainRequestInformation the_request);
        bool can_process(IContainRequestInformation request);
    }
}