using System.Web.Configuration;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(RequestCommand))]
    public class CommandSpecs
    {
        public abstract class concern : Observes<IProcessOneSpecificRequest,
                                            RequestCommand>
        {
        }

        public class when_determining_if_it_can_handle_a_request : concern
        {
            Establish c = () =>
            {
                depends.on<RequestSpecification>(x => true);
                request = fake.an<IContainRequestInformation>();
            };

            Because b = () =>
                result = sut.can_process(request);

            It should_make_the_determination_by_using_its_request_specification = () =>
                result.ShouldBeTrue();

            static bool result;
            static IContainRequestInformation request;
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                application_command = depends.on<IProcessAnApplicationBehaviour>();
                request = fake.an<IContainRequestInformation>();
            };

            Because b = () =>
                sut.process(request);

            It should_invoke_the_application_specific_behaviour_for_the_request = () =>
                application_command.received(x => x.process(request));


            static IContainRequestInformation request;
            static IProcessAnApplicationBehaviour application_command;
        }
    }
}