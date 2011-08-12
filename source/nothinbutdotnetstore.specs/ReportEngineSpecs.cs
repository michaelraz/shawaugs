using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ReportEngine))]
    public class ReportEngineSpecs
    {
        public abstract class concern : Observes<IRenderReports, ReportEngine>
        {
        }

        public class when_generating_a_view : concern
        {
            Establish c = () =>
            {
                the_current_context = ObjectFactory.create_http_context();
                template_registry = depends.on<IProvideReportTemplates>();
                depends.on<GetTheCurrentHttpContext>(() => the_current_context);
                template = fake.an<IReportTemplate<OurModel>>();
                the_model = new OurModel();

                template_registry.setup(reg => reg.get_template_for(the_model)).Return(template);
            };

            Because b = () =>
                sut.render(the_model);

            It should_tell_the_template_to_process_using_the_current_context = () =>
                template.received(x => x.ProcessRequest(the_current_context));


            static OurModel the_model;
            static IReportTemplate<OurModel> template;
            static IProvideReportTemplates template_registry;
            static HttpContext the_current_context;
        }
    }
}