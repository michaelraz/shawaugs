using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(RawHandler))]
    public class RawHandlerspecs
    {
        public abstract class concern : Observes<IHttpHandler,
                                            RawHandler>
        {
        }

        public class when_processing_an_incoming_http_context : concern
        {
            Establish c = () =>
            {
                front_controller = depends.on<IProcessWebRequests>();
                request_mapper = depends.on<ICreateRequestsTheFrontControllerCanProcess>();

                the_request =new object();
                incoming_request = ObjectFactory.create_http_context();

                request_mapper.setup(x => x.map_from(incoming_request)).Return(the_request);
            };

            Because b = () =>
                sut.ProcessRequest(incoming_request);

            It should_delegate_the_processing_of_the_request_To_the_front_controller = () =>
                front_controller.received(x => x.process(the_request));

            static IProcessWebRequests front_controller;
            static object the_request;
            static HttpContext incoming_request;
            static ICreateRequestsTheFrontControllerCanProcess request_mapper;
        }
    }
}