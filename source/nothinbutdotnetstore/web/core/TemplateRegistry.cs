using System.Web.Compilation;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class TemplateRegistry : IProvideReportTemplates
    {
        PageFactory page_factory;
        IProvidePathsToViews path_registry;

        public TemplateRegistry(PageFactory page_factory, IProvidePathsToViews path_registry)
        {
            this.page_factory = page_factory;
            this.path_registry = path_registry;
        }

        public IReportTemplate<Report> get_template_for<Report>(Report data)
        {
            var template = (IReportTemplate<Report>)page_factory(path_registry.get_the_path_to_a_page_that_can_display<Report>(),
                                        typeof(IReportTemplate<Report>));

            template.model = data;
            return template;
        }
    }
}