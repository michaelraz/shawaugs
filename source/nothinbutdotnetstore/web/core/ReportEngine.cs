using System.Web;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
    public class ReportEngine : IRenderReports
    {
        readonly IProvideReportTemplates template_registry;
        readonly GetTheCurrentHttpContext current_context_resolver;

        public ReportEngine(IProvideReportTemplates template_registry, GetTheCurrentHttpContext current_context_resolver)
        {
            this.template_registry = template_registry;
            this.current_context_resolver = current_context_resolver;
        }

        public void render<ReportModel>(ReportModel report_model)
        {
            template_registry.get_template_for(report_model).ProcessRequest(current_context_resolver());
        }
    }
}