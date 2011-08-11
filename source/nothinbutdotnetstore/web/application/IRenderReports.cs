namespace nothinbutdotnetstore.web.application
{
    public interface IRenderReports
    {
        void render<ReportModel>(ReportModel report_model);
    }
}