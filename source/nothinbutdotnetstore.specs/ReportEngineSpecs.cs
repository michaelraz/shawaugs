using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
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
                template_registry = depends.on<IProvideReportTemplates>();
                response = depends.on<IResponse>();
                template = fake.an<IReportTemplate<OurModel>>();
                report = fake.an<IReport>();
                the_model = new OurModel();

                template_registry.setup(reg => reg.get_template_for<OurModel>()).Return(template);
                template.setup(t => t.merge(the_model)).Return(report);
            };

            Because b = () =>
                sut.render(the_model);

            It should_merge_template_with_data = () =>
                template.received(x => x.merge(the_model));

            It should_supply_report_to_response = () =>
                response.received(x => x.send_content(report));

            static OurModel the_model;
            static IReportTemplate<OurModel> template;
            static IReport report;
            static IProvideReportTemplates template_registry;
            static IResponse response;
        }
    }
}