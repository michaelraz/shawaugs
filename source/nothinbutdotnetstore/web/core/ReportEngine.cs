using System;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
	public class ReportEngine : IRenderReports
	{
	    readonly IResponse response;
	    readonly IProvideReportTemplates template_registry;

	    public ReportEngine(IResponse response, IProvideReportTemplates template_registry)
	    {
	        this.response = response;
	        this.template_registry = template_registry;
	    }

	    public void render<ReportModel>(ReportModel report_model)
	    {
	        response.send_content(template_registry.get_template_for<ReportModel>().merge(report_model));
	    }
	}
}