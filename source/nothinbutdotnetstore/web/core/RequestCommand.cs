namespace nothinbutdotnetstore.web.core
{
    public class RequestCommand : IProcessOneSpecificRequest
    {
        RequestSpecification request_specification;
        IProcessAnApplicationBehaviour application_behaviour;

        public RequestCommand(RequestSpecification request_specification,
                              IProcessAnApplicationBehaviour application_behaviour)
        {
            this.request_specification = request_specification;
            this.application_behaviour = application_behaviour;
        }

        public void process(IContainRequestInformation the_request)
        {
            application_behaviour.process(the_request);
        }

        public bool can_process(IContainRequestInformation request)
        {
            return request_specification(request);
        }
    }
}