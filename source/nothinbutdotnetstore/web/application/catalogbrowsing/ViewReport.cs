using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewReport<ReportModel> : IProcessAnApplicationBehaviour
    {
        IRenderReports report_engine;
        IQuery<ReportModel> query;

        public ViewReport(IRenderReports report_engine, IQuery<ReportModel> query)
        {
            this.report_engine = report_engine;
            this.query = query;
        }

        public void process(IContainRequestInformation request)
        {
            report_engine.render(query.run(request));
        }
    }

    public interface IQuery<out ReportModel>
    {
        ReportModel run(IContainRequestInformation request);
    }
}