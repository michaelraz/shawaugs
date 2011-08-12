using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(TemplateRegistry))]
    public class TemplateRegistrySpecs
    {
        public abstract class concern : Observes<IProvideReportTemplates,
                                            TemplateRegistry>
        {
        }

        public class when_getting_a_template_that_can_display_a_particular_report_model : concern
        {
            Establish c = () =>
            {
                the_model = new TheModel();
                the_page_url = "sdfsdf.aspx";
                template = fake.an<IReportTemplate<TheModel>>();
                path_registry = depends.on<IProvidePathsToViews>();
                path_registry.setup(x => x.get_the_path_to_a_page_that_can_display<TheModel>())
                    .Return(the_page_url);

                depends.on<PageFactory>((page,type) =>
                {
                    page.ShouldEqual(the_page_url);
                    type.ShouldEqual(typeof(IReportTemplate<TheModel>));
                    return template;
                });
            };

            Because b = () =>
                result = sut.get_template_for(the_model);

            It should_return_the_http_handler_populated_with_its_data = () =>
                result.model.ShouldEqual(the_model);

            static IReportTemplate<TheModel> template;
            static TheModel the_model;
            static IReportTemplate<TheModel> result;
            static IProvidePathsToViews path_registry;
            static string the_page_url;
        }
    }

    public class TheModel
    {
    }
}