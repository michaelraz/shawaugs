 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
    [Subject(typeof(Command))]  
    public class CommandSpecs
    {
        public abstract class concern : Observes<IProcessOneSpecificRequest,
                                            Command>
        {
        
        }

   
        public class when_evaluating_a_request : concern
        {
            
            Establish c = () =>
            {
                request = fake.an<IContainRequestInformation>();
            };

            Because b = () =>
                result = sut.can_process(request);


            It should_return_true_if_it_can_process_request = () =>
                result.ShouldBeTrue();

            static bool result;
            static IContainRequestInformation request;
        }
    }
}
