using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewReport<>))]
    public class ViewReportSpec<InputModel, ReportModel>
    {
        public abstract class concern : Observes<IProcessAnApplicationBehaviour,
                                            ViewReport<ReportModel>>
        {
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                view_engine = depends.on<IRenderReports>();
                request = fake.an<IContainRequestInformation>();

                the_query = fake.an<IQuery<ReportModel>>();
                var repository = default(ReportModel);

            };

            Because b = () =>
                sut.process(request);

            It should_pass_the_response_from_the_repository_to_the_view_engine_to_be_rendered = () =>
                view_engine.received(x => x.render(repository));

            static IContainRequestInformation request;
            static IRenderReports view_engine;
            static IQuery<ReportModel> the_query;
            static InputModel model_type;
            static ReportModel repository;
        }
    }
}