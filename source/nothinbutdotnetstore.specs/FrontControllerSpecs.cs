 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
    [Subject(typeof(FrontController))]  
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<IProcessWebRequests,
                                            FrontController>
        {
        
        }

   
        public class when_processing_a_request : concern
        {

            Establish c = () =>
            {
                command_registry = depends.on<IFindCommandsThatCanProcessRequests>();
                command_that_can_process_request = fake.an<IProcessOneSpecificRequest>();
                the_request = fake.an<IContainRequestInformation>();

                command_registry.setup(x => x.get_command_for(the_request))
                    .Return(command_that_can_process_request);
            };

            Because b = () =>
                sut.process(the_request);


            It should_delegate_the_processing_to_the_command_that_can_process_the_request = () =>
                command_that_can_process_request.received(x => x.process(the_request));

            static IProcessOneSpecificRequest command_that_can_process_request;
            static IContainRequestInformation the_request;
            static IFindCommandsThatCanProcessRequests command_registry;
        }
    }
}
