using System.Web;

namespace nothinbutdotnetstore.web.application.stubs
{
    public class StubReportEngine : IRenderReports
    {
        public void render<ReportModel>(ReportModel report_model)
        {
            HttpContext.Current.Items.Add("blah",report_model);
            HttpContext.Current.Server.Transfer("~/views/ProductBrowser.aspx",true);
        }
    }
}