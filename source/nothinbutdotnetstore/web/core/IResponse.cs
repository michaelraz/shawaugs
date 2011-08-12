namespace nothinbutdotnetstore.web.core
{
    public interface IResponse
    {
        void send_content(IReport report);
    }

    public interface IProvideReportTemplates
    {
        IReportTemplate<Model> get_template_for<Model>();
    }

    public interface IReportTemplate<Model>
    {
        IReport merge(Model the_model);
    }

    public interface IReport
    {
    }
}
