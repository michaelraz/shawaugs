namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubMissingCommand
    {
        public IProcessOneSpecificRequest create()
        {
            return new StubCommand();
        }

        class StubCommand : IProcessOneSpecificRequest
        {
            public void process(IContainRequestInformation request)
            {
            }

            public bool can_process(IContainRequestInformation request)
            {
                return false;
            }
        }
    }
}