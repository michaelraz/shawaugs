using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewReport<>))]
    public class ViewReportSpec
    {
        public abstract class concern : Observes<IProcessAnApplicationBehaviour,
                                            ViewReport<OurModel>>
        {
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                view_engine = depends.on<IRenderReports>();
                the_query = depends.on<IQuery<OurModel>>();
                request = fake.an<IContainRequestInformation>();
                the_model = new OurModel();

                the_query.setup(x => x.run( request)).Return(the_model);
            };

            Because b = () =>
                sut.process(request);

            It should_pass_the_response_from_the_repository_to_the_view_engine_to_be_rendered = () =>
                view_engine.received(x => x.render(the_model));

            static IContainRequestInformation request;
            static IRenderReports view_engine;
            static IQuery<OurModel> the_query;
            static OurModel the_model;
        }
    }

    public class OurModel
    {
    }
}